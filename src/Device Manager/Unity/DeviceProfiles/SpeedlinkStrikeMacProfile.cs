namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    [AutoDiscover]
    public class SpeedlinkStrikeMacProfile : UnityInputDeviceProfile {

        public SpeedlinkStrikeMacProfile() {
            Name = "Speedlink Strike Controller";
            Meta = "Speedlink Strike Controller on Mac (Analog Mode)";

            SupportedPlatforms = new[] {
                "OS X"
            };

            JoystickNames = new[] {
                "DragonRise Inc.   Generic   USB  Joystick  "
            };

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "3",
                    Target = InputControlTypes.Action1,
                    Source = Button2
                },
                new InputControlMapping {
                    Handle = "2",
                    Target = InputControlTypes.Action2,
                    Source = Button1
                },
                new InputControlMapping {
                    Handle = "4",
                    Target = InputControlTypes.Action3,
                    Source = Button3
                },
                new InputControlMapping {
                    Handle = "1",
                    Target = InputControlTypes.Action4,
                    Source = Button0
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
                    Handle = "10",
                    Target = InputControlTypes.Start,
                    Source = Button9
                },
                new InputControlMapping {
                    Handle = "9",
                    Target = InputControlTypes.Select,
                    Source = Button8
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
                },
                new InputControlMapping {
                    Handle = "Left Stick Button",
                    Target = InputControlTypes.LeftStickButton,
                    Source = Button10
                },
                new InputControlMapping {
                    Handle = "Right Stick Button",
                    Target = InputControlTypes.RightStickButton,
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
                    Source = Analog3
                },
                new InputControlMapping {
                    Handle = "Right Stick Y",
                    Target = InputControlTypes.RightStickY,
                    Source = Analog4,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "DPad Left",
                    Target = InputControlTypes.DPadLeft,
                    Source = Analog5,
                    SourceRange = InputControlMapping.Range.Negative,
                    TargetRange = InputControlMapping.Range.Negative,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "DPad Right",
                    Target = InputControlTypes.DPadRight,
                    Source = Analog5,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Analog6,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive
                },
                new InputControlMapping {
                    Handle = "DPad Up",
                    Target = InputControlTypes.DPadUp,
                    Source = Analog6,
                    SourceRange = InputControlMapping.Range.Negative,
                    TargetRange = InputControlMapping.Range.Negative,
                    Invert = true
                }
            };
        }

    }

}