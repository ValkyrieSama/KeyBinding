namespace ValhallaGames.Unity.DeviceDetection {

    public class UnityUnknownDeviceProfile : UnityInputDeviceProfile {

        public UnityUnknownDeviceProfile(string joystickName) {
            Name = "Unknown Device";
            if (joystickName != "") Name += " (" + joystickName + ")";

            Meta = "";
            Sensitivity = 1.0f;
            LowerDeadZone = 0.2f;

            SupportedPlatforms = null;
            JoystickNames = new[] {joystickName};

            AnalogMappings = new InputControlMapping[UnityInputDevice.MaxAnalogs];
            for (var i = 0; i < UnityInputDevice.MaxAnalogs; ++i)
                AnalogMappings[i] = new InputControlMapping {
                    Handle = "Analog " + i,
                    Source = Analog(i),
                    Target = InputControlTypes.Analog0 + i
                };

            ButtonMappings = new InputControlMapping[UnityInputDevice.MaxButtons];
            for (var i = 0; i < UnityInputDevice.MaxButtons; ++i)
                ButtonMappings[i] = new InputControlMapping {
                    Handle = "Button " + i,
                    Source = Button(i),
                    Target = InputControlTypes.Button0 + i
                };
        }

        public override bool IsKnown {
            get { return false; }
        }

    }

}