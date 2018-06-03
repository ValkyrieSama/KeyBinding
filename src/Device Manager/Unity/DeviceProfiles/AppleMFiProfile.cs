namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    [AutoDiscover]
    public class AppleMFiProfile : UnityInputDeviceProfile {

        public AppleMFiProfile() {
            Name = "Apple MFi Controller";
            Meta = "Apple MFi Controller on iOS";

            SupportedPlatforms = new[] {
                "iPhone"
            };

            LastResortRegex = ""; // Match anything.

            LowerDeadZone = 0.05f;
            UpperDeadZone = 0.95f;

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "A",
                    Target = InputControlTypes.Action1,
                    Source = Button14
                },
                new InputControlMapping {
                    Handle = "B",
                    Target = InputControlTypes.Action2,
                    Source = Button13
                },
                new InputControlMapping {
                    Handle = "X",
                    Target = InputControlTypes.Action3,
                    Source = Button15
                },
                new InputControlMapping {
                    Handle = "Y",
                    Target = InputControlTypes.Action4,
                    Source = Button12
                },
                new InputControlMapping {
                    Handle = "DPad Up",
                    Target = InputControlTypes.DPadUp,
                    Source = Button4
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Button6
                },
                new InputControlMapping {
                    Handle = "DPad Left",
                    Target = InputControlTypes.DPadLeft,
                    Source = Button7
                },
                new InputControlMapping {
                    Handle = "DPad Right",
                    Target = InputControlTypes.DPadRight,
                    Source = Button5
                },
                new InputControlMapping {
                    Handle = "Left Bumper",
                    Target = InputControlTypes.LeftBumper,
                    Source = Button8
                },
                new InputControlMapping {
                    Handle = "Right Bumper",
                    Target = InputControlTypes.RightBumper,
                    Source = Button9
                },
                new InputControlMapping {
                    Handle = "Pause",
                    Target = InputControlTypes.Pause,
                    Source = Button0
                },
                new InputControlMapping {
                    Handle = "Left Trigger",
                    Target = InputControlTypes.LeftTrigger,
                    Source = Button10
                },
                new InputControlMapping {
                    Handle = "Right Trigger",
                    Target = InputControlTypes.RightTrigger,
                    Source = Button11
                }
            };

            AnalogMappings = new[] {
                new InputControlMapping {
                    Handle = "Left Stick X",
                    Target = InputControlTypes.LeftStickX,
                    Source = Analog0
                },
                new InputControlMapping {
                    Handle = "Left Stick Y",
                    Target = InputControlTypes.LeftStickY,
                    Source = Analog1,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "Right Stick X",
                    Target = InputControlTypes.RightStickX,
                    Source = Analog2
                },
                new InputControlMapping {
                    Handle = "Right Stick Y",
                    Target = InputControlTypes.RightStickY,
                    Source = Analog3,
                    Invert = true
                }
            };
        }

    }

}