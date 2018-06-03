namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    // Tested with Samsung Galaxy Note 2 connected by OTG cable.
    [AutoDiscover]
    public class PlayStation4AndroidProfile : UnityInputDeviceProfile {

        public PlayStation4AndroidProfile() {
            Name = "PlayStation 4 Controller";
            Meta = "PlayStation 4 Controller on Android";

            SupportedPlatforms = new[] {
                "Android"
            };

            JoystickNames = new[] {
                "Sony Computer Entertainment Wireless Controller"
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
                    Source = Button13
                },
                new InputControlMapping {
                    Handle = "Square",
                    Target = InputControlTypes.Action3,
                    Source = Button0
                },
                new InputControlMapping {
                    Handle = "Triangle",
                    Target = InputControlTypes.Action4,
                    Source = Button2
                },
                new InputControlMapping {
                    Handle = "Left Bumper",
                    Target = InputControlTypes.LeftBumper,
                    Source = Button3
                },
                new InputControlMapping {
                    Handle = "Right Bumper",
                    Target = InputControlTypes.RightBumper,
                    Source = Button14
                },
                new InputControlMapping {
                    Handle = "Share",
                    Target = InputControlTypes.Share,
                    Source = Button7
                },
                new InputControlMapping {
                    Handle = "Options",
                    Target = InputControlTypes.Options,
                    Source = Button6
                },
                new InputControlMapping {
                    Handle = "Left Stick Button",
                    Target = InputControlTypes.LeftStickButton,
                    Source = Button11
                },
                new InputControlMapping {
                    Handle = "Right Stick Button",
                    Target = InputControlTypes.RightStickButton,
                    Source = Button10
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
                    Source = Analog13
                },
                new InputControlMapping {
                    Handle = "Right Stick Y",
                    Target = InputControlTypes.RightStickY,
                    Source = Analog14,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "Left Trigger",
                    Target = InputControlTypes.LeftTrigger,
                    Source = Analog2,
                    SourceRange = InputControlMapping.Range.Complete,
                    TargetRange = InputControlMapping.Range.Positive
                },
                new InputControlMapping {
                    Handle = "Right Trigger",
                    Target = InputControlTypes.RightTrigger,
                    Source = Analog3,
                    SourceRange = InputControlMapping.Range.Complete,
                    TargetRange = InputControlMapping.Range.Positive
                },
                new InputControlMapping {
                    Handle = "DPad Left",
                    Target = InputControlTypes.DPadLeft,
                    Source = Analog4,
                    SourceRange = InputControlMapping.Range.Negative,
                    TargetRange = InputControlMapping.Range.Negative,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "DPad Right",
                    Target = InputControlTypes.DPadRight,
                    Source = Analog4,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive
                },
                new InputControlMapping {
                    Handle = "DPad Up",
                    Target = InputControlTypes.DPadUp,
                    Source = Analog5,
                    SourceRange = InputControlMapping.Range.Negative,
                    TargetRange = InputControlMapping.Range.Negative,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Analog5,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive
                }
            };
        }

    }

}