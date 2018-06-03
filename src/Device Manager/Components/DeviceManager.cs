using System;
using System.Collections.Generic;
using UnityEngine;
using ValhallaGames.Unity.Utility;
using System.Collections.ObjectModel;

namespace ValhallaGames.Unity.DeviceDetection {

    public class DeviceManager : Manager {

        [SerializeField]
        private bool invertYAxis = false, enableXInput = false, useFixedUpdate = false;
        [SerializeField]
        private List<string> customProfiles = new List<string>();

        public static DeviceManager Instance { get; private set; }

        /// <summary>
        /// Gets the devices connected.
        /// </summary>
        /// <value>The devices.</value>
        public static ReadOnlyCollection<InputDevice> Devices { get { return DeviceTracker.Devices; } }

        /// <summary>
        /// Get the last device who was modified
        /// </summary>
        /// <value>The active device.</value>
        public static InputDevice ActiveDevice { get { return DeviceTracker.ActiveDevice; } }

        /// <summary>
        /// Get the active device of the first device connected
        /// </summary>
        /// <value>The default active device.</value>
        public static InputDevice DefaultActiveDevice { get { return DeviceTracker.DefaultActiveDevice; } }

        protected virtual void Awake() {
            if (Instance == null) 
                Instance = this;
            else if (Instance != this) 
                Destroy(this);
        }

        protected override void OnEnable() {
            if (isDebugMode) {
                Debug.Log("ValkyrieSama's Controller (version " + InputManager.Version + ")");
                Logger.OnLogMessage += HandleOnLogMessage;
            }

            InputManager.InvertYAxis = invertYAxis;
            InputManager.EnableXInput = enableXInput;
            InputManager.SetupInternal();

            foreach (var className in customProfiles) {
                var classType = Type.GetType(className);
                if (classType == null) { Debug.LogError("Cannot find class for custom profile: " + className); } 
                else {
                    var customProfileInstance = Activator.CreateInstance(classType) as UnityInputDeviceProfile;
                    InputManager.AttachDevice(new UnityInputDevice(customProfileInstance));
                }
            }
        }

        protected virtual void OnDisable() { InputManager.ResetInternal(); }

#if UNITY_ANDROID && CONTROL_OUYA && !UNITY_EDITOR
		void Start() {
			StartCoroutine( CheckForOuyaEverywhereSupport() );
		}


		IEnumerator CheckForOuyaEverywhereSupport() {
			while (!OuyaSDK.isIAPInitComplete()) {
				yield return null;
			}

			OuyaEverywhereDeviceManager.Enable();
		}
#endif
       
        protected virtual void Update() {
            if (!useFixedUpdate || Mathf.Approximately(Time.timeScale, 0.0f)) InputManager.UpdateInternal();
        }

        protected virtual void FixedUpdate() { if (useFixedUpdate) InputManager.UpdateInternal(); }

        protected virtual void OnApplicationFocus(bool focusState) { InputManager.OnApplicationFocus(focusState); }

        protected virtual void OnApplicationPause(bool pauseState) { InputManager.OnApplicationPause(pauseState); }

        /// <summary>
        /// Get a specific device
        /// </summary>
        /// <returns>The device.</returns>
        /// <param name="joystickId">Joystick identifier.</param>
        public static InputDevice GetDevice(int joystickId) {
            return InputManager.GetDevice(joystickId);
        }

        /// <summary>
        /// Get a specific control from a device
        /// </summary>
        /// <returns>The control.</returns>
        /// <param name="joystickId">Joystick identifier.</param>
        /// <param name="type">Type.</param>
        public static InputControl GetControl(int joystickId, InputControlTypes type) {
            return InputManager.GetDevice(joystickId).GetControl(type);
        }

        /// <summary>
        /// Raises the application quit event in the InputManager.
        /// </summary>
        private void OnApplicationQuit() { InputManager.OnApplicationQuit(); }

        /// <summary>
        /// Handles the onLogMessage.
        /// </summary>
        /// <param name="logMessage">Log message.</param>
        private static void HandleOnLogMessage(LogMessage logMessage) {
            switch (logMessage.Type) {
                case LogMessageType.Info:
                    Debug.Log(logMessage.Text);
                    break;
                case LogMessageType.Warning:
                    Debug.LogWarning(logMessage.Text);
                    break;
                case LogMessageType.Error:
                    Debug.LogError(logMessage.Text);
                    break;
                default:
                    return;
            }
        }

    }

}