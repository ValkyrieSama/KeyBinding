using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public class UnityButtonSource : IInputControlSource {

        private static string[,] buttonQueries;
        private int buttonId;

        public UnityButtonSource(int buttonId) {
            this.buttonId = buttonId;
            SetupButtonQueries();
        }

        public float GetValue(InputDevice inputDevice) { return GetState(inputDevice) ? 1.0f : 0.0f; }

        public bool GetState(InputDevice inputDevice) {
            var joystickId = (inputDevice as UnityInputDevice).JoystickId;
            var buttonKey = GetButtonKey(joystickId, buttonId);
            return Input.GetKey(buttonKey);
        }

        private static void SetupButtonQueries() {
            if (buttonQueries == null) {
                buttonQueries = new string[UnityInputDevice.MaxDevices, UnityInputDevice.MaxButtons];

                for (var joystickId = 1; joystickId <= UnityInputDevice.MaxDevices; joystickId++)
                for (var buttonId = 0; buttonId < UnityInputDevice.MaxButtons; buttonId++)
                    buttonQueries[joystickId - 1, buttonId] = "joystick " + joystickId + " button " + buttonId;
            }
        }

        private static string GetButtonKey(int joystickId, int buttonId) {
            return buttonQueries[joystickId - 1, buttonId];
        }

    }

}