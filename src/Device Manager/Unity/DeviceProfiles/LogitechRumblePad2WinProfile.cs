namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    [AutoDiscover]
    public class LogitechRumblePad2WinProfile : UnityInputDeviceProfile {

        public LogitechRumblePad2WinProfile() {
            Name = "Logitech RumblePad 2 Controller";
            Meta = "Logitech RumblePad 2 Controller on Windows";

            SupportedPlatforms = new[] {
                "Windows"
            };

            JoystickNames = new[] {
                "Logitech Rumblepad 2 USB"
            };

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "1",
                    Target = InputControlTypes.Action3,
                    Source = Button0
                },
                new InputControlMapping {
                    Handle = "2",
                    Target = InputControlTypes.Action1,
                    Source = Button1
                },
                new InputControlMapping {
                    Handle = "3",
                    Target = InputControlTypes.Action2,
                    Source = Button2
                },
                new InputControlMapping {
                    Handle = "4",
                    Target = InputControlTypes.Action4,
                    Source = Button3
                },
                new InputControlMapping {
                    Handle = "9",
                    Target = InputControlTypes.Back,
                    Source = Button8
                },
                new InputControlMapping {
                    Handle = "10",
                    Target = InputControlTypes.Start,
                    Source = Button9
                },
                new InputControlMapping {
                    Handle = "Left Stick Button",
                    Target = InputControlTypes.LeftStickButton,
                    Source = Button11
                },
                new InputControlMapping {
                    Handle = "Right Stick Button",
                    Target = InputControlTypes.RightStickButton,
                    Source = Button12
                },
                new InputControlMapping {
                    Handle = "Left Bumper",
                    Target = InputControlTypes.LeftBumper,
                    Source = Button4
                },
                new InputControlMapping {
                    Handle = "Right Bumper",
                    Target = InputControlTypes.RightBumper,
                    Source = Button5
                },
                new InputControlMapping {
                    Handle = "Left Trigger",
                    Target = InputControlTypes.LeftTrigger,
                    Source = Button6
                },
                new InputControlMapping {
                    Handle = "Right Trigger",
                    Target = InputControlTypes.RightTrigger,
                    Source = Button7
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
                },
                new InputControlMapping {
                    Handle = "DPad Left",
                    Target = InputControlTypes.DPadLeft,
                    Source = Analog4,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "DPad Right",
                    Target = InputControlTypes.DPadRight,
                    Source = Analog4
                },
                new InputControlMapping {
                    Handle = "DPad Up",
                    Target = InputControlTypes.DPadUp,
                    Source = Analog5,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Analog5
                }
            };
        }

    }

}