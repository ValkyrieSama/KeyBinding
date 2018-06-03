namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    [AutoDiscover]
    public class PlayStation4WinProfile : UnityInputDeviceProfile {

        public PlayStation4WinProfile() {
            Name = "PlayStation 4 Controller";
            Meta = "PlayStation 4 Controller on Windows";

            SupportedPlatforms = new[] {
                "Windows"
            };

            JoystickNames = new[] {
                "Wireless Controller"
            };

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "Cross",
                    Target = InputControlTypes.Action1,
                    Source = Button1
                },
                new InputControlMapping {
                    Handle = "Circle",
                    Target = InputControlTypes.Action2,
                    Source = Button2
                },
                new InputControlMapping {
                    Handle = "Square",
                    Target = InputControlTypes.Action3,
                    Source = Button0
                },
                new InputControlMapping {
                    Handle = "Triangle",
                    Target = InputControlTypes.Action4,
                    Source = Button3
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
                    Handle = "Share",
                    Target = InputControlTypes.Share,
                    Source = Button8
                },
                new InputControlMapping {
                    Handle = "Options",
                    Target = InputControlTypes.Select,
                    Source = Button9
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
                },
                new InputControlMapping {
                    Handle = "System",
                    Target = InputControlTypes.System,
                    Source = Button12
                },
                new InputControlMapping {
                    Handle = "TouchPad Button",
                    Target = InputControlTypes.TouchPadTap,
                    Source = Button13
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
                    Source = Analog5,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "Left Trigger",
                    Target = InputControlTypes.LeftTrigger,
                    Source = Analog3,
                    SourceRange = InputControlMapping.Range.Complete,
                    TargetRange = InputControlMapping.Range.Positive,
                    IgnoreInitialZeroValue = true
                },
                new InputControlMapping {
                    Handle = "Right Trigger",
                    Target = InputControlTypes.RightTrigger,
                    Source = Analog4,
                    SourceRange = InputControlMapping.Range.Complete,
                    TargetRange = InputControlMapping.Range.Positive,
                    IgnoreInitialZeroValue = true
                },
                new InputControlMapping {
                    Handle = "DPad Left",
                    Target = InputControlTypes.DPadLeft,
                    Source = Analog6,
                    SourceRange = InputControlMapping.Range.Negative,
                    TargetRange = InputControlMapping.Range.Negative,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "DPad Right",
                    Target = InputControlTypes.DPadRight,
                    Source = Analog6,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive
                },
                new InputControlMapping {
                    Handle = "DPad Up",
                    Target = InputControlTypes.DPadUp,
                    Source = Analog7,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Analog7,
                    SourceRange = InputControlMapping.Range.Negative,
                    TargetRange = InputControlMapping.Range.Negative,
                    Invert = true
                }
            };
        }

    }

}