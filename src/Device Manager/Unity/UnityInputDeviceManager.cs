using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ValhallaGames.Unity.Utility;

namespace ValhallaGames.Unity.DeviceDetection {

    public class UnityInputDeviceManager : InputDeviceManager {

        private const float DEVICE_REFRESH_INTERVAL = 1.0f;

        private List<UnityInputDeviceProfile> deviceProfiles = new List<UnityInputDeviceProfile>();
        private float deviceRefreshTimer;
        private string joystickHash = "";
        private bool keyboardDevicesAttached;

        public UnityInputDeviceManager() {
            AutoDiscoverDeviceProfiles();
            RefreshDevices();
        }

        private static string JoystickHash {
            get {
                var joystickNames = Input.GetJoystickNames();
                return joystickNames.Length + ": " + string.Join(", ", joystickNames);
            }
        }

        public override void Update(ulong updateTick, float deltaTime) {
            deviceRefreshTimer += deltaTime;
            if (!string.IsNullOrEmpty(joystickHash) && !(deviceRefreshTimer >= DEVICE_REFRESH_INTERVAL)) return;
            deviceRefreshTimer = 0.0f;

            if (joystickHash == JoystickHash) return;
            Messages.LogDevicesChangesDetected();
            RefreshDevices();
        }

        private void RefreshDevices() {
            AttachKeyboardDevices();
            DetectAttachedJoystickDevices();
            DetectDetachedJoystickDevices();
            joystickHash = JoystickHash;
        }

        private void AttachDevice(InputDevice device) {
            Devices.Add(device);
            InputManager.AttachDevice(device);
        }

        private void AttachKeyboardDevices() {
            foreach (var deviceProfile in deviceProfiles)
                if (deviceProfile.IsNotJoystick && deviceProfile.IsSupportedOnThisPlatform)
                    AttachKeyboardDeviceWithConfig(deviceProfile);
        }

        private void AttachKeyboardDeviceWithConfig(UnityInputDeviceProfile config) {
            if (keyboardDevicesAttached) return;

            var keyboardDevice = new UnityInputDevice(config);
            AttachDevice(keyboardDevice);

            keyboardDevicesAttached = true;
        }

        private void DetectAttachedJoystickDevices() {
            try {
                var joystickNames = Input.GetJoystickNames();
                for (var i = 0; i < joystickNames.Length; i++) DetectAttachedJoystickDevice(i + 1, joystickNames[i]);
            } catch (Exception e) { Logger.LogError(e.Message + " " + e.StackTrace); }
        }

        private void DetectAttachedJoystickDevice(int joystickId, string joystickName) {
            if (joystickName.IndexOf("WIRED CONTROLLER", StringComparison.OrdinalIgnoreCase) != -1) return;
            if (joystickName.IndexOf("webcam", StringComparison.OrdinalIgnoreCase) != -1) return;

            if (PlatformHelper.IsMac() && IsMacUnknownDevice(joystickName)) return;
            if (PlatformHelper.IsWindows() && IsWindowsUnknownDevice(joystickName)) return;

            var matchedDeviceProfile = FindDeviceProfile(joystickName);
            var deviceProfile = matchedDeviceProfile ?? CreateUnknownDeviceProfile(joystickName);

            if (IsAlreadyConfigured(joystickId, deviceProfile)) {
                Messages.LogAlreadyConfiguredDevice(joystickName, deviceProfile);
                return;
            }

            if (!deviceProfile.IsHidden) {
                AttachDevice(new UnityInputDevice(deviceProfile, joystickId));

                if (matchedDeviceProfile != null)
                    Messages.LogKnownDevice(joystickId, deviceProfile);
                else
                    Messages.LogUnknownDevice(joystickId, joystickName);
            } else
                Messages.LogHiddenDevice(joystickId, deviceProfile);
        }

        private void DetectDetachedJoystickDevices() {
            var joystickNames = Input.GetJoystickNames();

            foreach (var inputDevice in Devices) {
                var device = (UnityInputDevice)inputDevice;
                if (device.Profile.IsNotJoystick) continue;

                if (joystickNames.Length >= device.JoystickId &&
                    device.Profile.HasJoystickOrRegexName(joystickNames[device.JoystickId - 1])) continue;
                Devices.Remove(device);
                InputManager.DetachDevice(device);
                Messages.LogDetachedDevice(device);
            }
        }

        private void AutoDiscoverDeviceProfiles() {
            foreach (var typeName in UnityInputDeviceProfileList.Profiles) {
                var deviceProfile = (UnityInputDeviceProfile)Activator.CreateInstance(Type.GetType(typeName));
                if (deviceProfile.IsSupportedOnThisPlatform) deviceProfiles.Add(deviceProfile);
            }
        }

        private UnityInputDeviceProfile FindDeviceProfile(string joystickName) {
            return deviceProfiles.Find(config => config.HasJoystickOrRegexName(joystickName));
        }

        private UnityInputDeviceProfile CreateUnknownDeviceProfile(string joystickName) {
            var deviceProfile = new UnityUnknownDeviceProfile(joystickName);
            deviceProfiles.Add(deviceProfile);
            return deviceProfile;
        }

        private bool IsAlreadyConfigured(int joystickId, UnityInputDeviceProfile deviceProfile) {
            return Devices.OfType<UnityInputDevice>().Any(unityDevice => unityDevice.IsConfiguredWith(deviceProfile, joystickId));
        }

        public static bool IsMacUnknownDevice(string unityJoystickName) {
            // PS4 controller works properly as of Unity 4.5
            return InputManager.UnityVersion <= new VersionInfo(4, 5) && string.Equals(unityJoystickName, "Unknown Wireless Controller", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsWindowsUnknownDevice(string unityJoystickName) {
            // As of Unity 4.6.3p1, empty strings on windows represent disconnected devices.
            return InputManager.UnityVersion >= new VersionInfo(4, 6, 3) && string.IsNullOrEmpty(unityJoystickName);
        }
    }

}