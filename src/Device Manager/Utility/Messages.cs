namespace ValhallaGames.Unity.DeviceDetection {

    public static class Messages {
        
        public static void LogDevicesChangesDetected() {
            Logger.LogInfo("Change in Unity attached joysticks detected; refreshing device list.");
        }

        public static void LogAlreadyConfiguredDevice(string joystickName, UnityInputDeviceProfile deviceProfile) {
            Logger.LogInfo("Device \"" + joystickName + "\" is already configured with " + deviceProfile.Name);
        }

        public static void LogKnownDevice(int joystickId, UnityInputDeviceProfile deviceProfile) {
            Logger.LogInfo("Device " + joystickId + " matched profile " + deviceProfile.GetType().Name + " (" + deviceProfile.Name + ")");
        }

        public static void LogUnknownDevice(int joystickId, string joystickName) {
            Logger.LogWarning("Device " + joystickId + " with name \"" + joystickName + "\" does not match any known profiles.");
        }

        public static void LogHiddenDevice(int joystickId, UnityInputDeviceProfile deviceProfile) {
            Logger.LogInfo("Device " + joystickId + " matching profile " + deviceProfile.GetType().Name + " (" + deviceProfile.Name + ")" + " is hidden and will not be attached.");
        }

        public static void LogDetachedDevice(UnityInputDevice device) {
            Logger.LogInfo("Detached device: " + device.Profile.Name);
        }

    }

}