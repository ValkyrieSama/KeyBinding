using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public class InputManager {

        public static readonly VersionInfo Version = VersionInfo.ValkyrieLibraryVersion();

        private static List<InputDeviceManager> inputDeviceManagers = new List<InputDeviceManager>();

        public static bool InvertYAxis;

        private static bool isSetup;

        private static float initialTime, currentTime, lastUpdateTime;

        private static ulong currentTick;

        private static VersionInfo? unityVersion;

        public static string Platform { get; private set; }

        public static bool MenuWasPressed { get; private set; }

        public static bool EnableXInput { get; set; }

        public static VersionInfo UnityVersion {
            get {
                if (!unityVersion.HasValue) unityVersion = VersionInfo.UnityVersion();

                return unityVersion.Value;
            }
        }

        public static event Action OnSetup;
        public static event Action<ulong, float> OnUpdate;

        internal static void SetupInternal() {
            if (isSetup) return;

            Platform = (SystemInfo.operatingSystem + " " + SystemInfo.deviceModel).ToUpper();

            initialTime = 0.0f;
            currentTime = 0.0f;
            lastUpdateTime = 0.0f;
            currentTick = 0;

            inputDeviceManagers.Clear();
            DeviceTracker.Setup();

            isSetup = true;

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
            if (EnableXInput) XInputDeviceManager.Enable();
#endif

            if (OnSetup != null) {
                OnSetup.Invoke();
                OnSetup = null;
            }

#if UNITY_ANDROID && CONTROL_OUYA && !UNITY_EDITOR
			addUnityInputDeviceManager = false;
			#endif

            AddDeviceManager<UnityInputDeviceManager>();
        }

        internal static void ResetInternal() {
            OnSetup = null;
            OnUpdate = null;
            DeviceTracker.Reset();

            inputDeviceManagers.Clear();

            isSetup = false;
        }

        private static void AssertIsSetup() {
            if (!isSetup) throw new Exception("InputManager is not initialized. Call InputManager.Setup() first.");
        }

        internal static void UpdateInternal() {
            try {
                AssertIsSetup();
                if (OnSetup != null) {
                    OnSetup.Invoke();
                    OnSetup = null;
                }

                currentTick++;
                UpdateCurrentTime();
                var deltaTime = currentTime - lastUpdateTime;

                UpdateDeviceManagers(deltaTime);

                PreUpdateDevices(deltaTime);
                UpdateDevices(deltaTime);
                PostUpdateDevices(deltaTime);

                DeviceTracker.UpdateActiveDevice();

                lastUpdateTime = currentTime;
            } catch (Exception) { }
        }

        internal static void OnApplicationFocus(bool focusState) {
            if (focusState) return;
            foreach (var device in DeviceTracker.Devices)
                foreach (var inputControl in device.Controls) 
                        if (inputControl != null) 
                            inputControl.SetZeroTick();
        }

        internal static void OnApplicationPause(bool pauseState) { }

        internal static void OnApplicationQuit() { }

        public static InputDevice GetDevice(int joystickId) {
            foreach (var device in DeviceTracker.Devices) 
                if (((UnityInputDevice) device).JoystickId == joystickId) 
                    return device;
            return InputDevice.Null;
        }

        public static void AddDeviceManager(InputDeviceManager inputDeviceManager) {
            AssertIsSetup();

            inputDeviceManagers.Add(inputDeviceManager);
            inputDeviceManager.Update(currentTick, currentTime - lastUpdateTime);
        }

        public static void AddDeviceManager<T>() where T : InputDeviceManager, new() {
            if (!HasDeviceManager<T>()) 
                AddDeviceManager(new T());
        }

        public static bool HasDeviceManager<T>() where T : InputDeviceManager { return inputDeviceManagers.OfType<T>().Any(); }


        public static void AttachDevice(InputDevice device) {
            AssertIsSetup();
            DeviceTracker.AttachDevice(device);
        }

        public static void DetachDevice(InputDevice device) {
            AssertIsSetup();
            DeviceTracker.DetachDevice(device);
        }

        public static void HideDevicesWithProfile(Type type) {
#if !UNITY_EDITOR && UNITY_METRO
			if (type.GetTypeInfo().IsAssignableFrom(typeof(UnityInputDeviceProfile).GetTypeInfo()))
			#else
            if (type.IsSubclassOf(typeof(UnityInputDeviceProfile)))
#endif
                UnityInputDeviceProfile.Hide(type);
        }

        private static void UpdateCurrentTime() {
            // Have to do this hack since Time.realtimeSinceStartup is not set until AFTER Awake().
            if (initialTime < float.Epsilon) initialTime = Time.realtimeSinceStartup;

            currentTime = Mathf.Max(0.0f, Time.realtimeSinceStartup - initialTime);
        }

        private static void UpdateDeviceManagers(float deltaTime) {
            foreach (var inputDeviceManager in inputDeviceManagers) inputDeviceManager.Update(currentTick, deltaTime);
        }

        private static void PreUpdateDevices(float deltaTime) {
            MenuWasPressed = false;

            foreach (var device in DeviceTracker.Devices) device.PreUpdate(currentTick, deltaTime);
        }

        private static void UpdateDevices(float deltaTime) {
            foreach (var device in DeviceTracker.Devices) device.Update(currentTick, deltaTime);

            if (OnUpdate != null) OnUpdate.Invoke(currentTick, deltaTime);
        }

        private static void PostUpdateDevices(float deltaTime) {
            foreach (var device in DeviceTracker.Devices) {
                device.PostUpdate(currentTick, deltaTime);

                if (device.MenuWasPressed) MenuWasPressed = true;
            }
        }
    }

}