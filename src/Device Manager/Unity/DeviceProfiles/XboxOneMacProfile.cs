namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    [AutoDiscover]
    public class XboxOneMacProfile : UnityInputDeviceProfile {

        public XboxOneMacProfile() {
            Name = "XBox One Controller";
            Meta = "XBox One Controller on OSX";

            SupportedPlatforms = new[] {
                "OS X"
            };

            JoystickNames = new[] {
                "Microsoft Xbox One Wired Controller"
            };

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "A",
                    Target = InputControlTypes.Action1,
                    Source = Button16
                },
                new InputControlMapping {
                    Handle = "B",
                    Target = InputControlTypes.Action2,
                    Source = Button17
                },
                new InputControlMapping {
                    Handle = "X",
                    Target = InputControlTypes.Action3,
                    Source = Button18
                },
                new InputControlMapping {
                    Handle = "Y",
                    Target = InputControlTypes.Action4,
                    Source = Button19
                },
                new InputControlMapping {
                    Handle = "DPad Left",
                    Target = InputControlTypes.DPadLeft,
                    Source = Button7
                },
                new InputControlMapping {
                    Handle = "DPad Right",
                    Target = InputControlTypes.DPadRight,
                    Source = Button8
                },
                new InputControlMapping {
                    Handle = "DPad Up",
                    Target = InputControlTypes.DPadUp,
                    Source = Button5
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Button6
                },
                new InputControlMapping {
                    Handle = "Left Bumper",
                    Target = InputControlTypes.LeftBumper,
                    Source = Button13
                },
                new InputControlMapping {
                    Handle = "Right Bumper",
                    Target = InputControlTypes.RightBumper,
                    Source = Button14
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
                    Handle = "View",
                    Target = InputControlTypes.View,
                    Source = Button10
                },
                new InputControlMapping {
                    Handle = "Menu",
                    Target = InputControlTypes.Menu,
                    Source = Button9
                },
                new InputControlMapping {
                    Handle = "Guide",
                    Target = InputControlTypes.System,
                    Source = Button15
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
                    Handle = "Left Trigger",
                    Target = InputControlTypes.LeftTrigger,
                    Source = Analog4,
                    SourceRange = InputControlMapping.Range.Complete,
                    TargetRange = InputControlMapping.Range.Positive,
                    IgnoreInitialZeroValue = true
                },
                new InputControlMapping {
                    Handle = "Right Trigger",
                    Target = InputControlTypes.RightTrigger,
                    Source = Analog5,
                    SourceRange = InputControlMapping.Range.Complete,
                    TargetRange = InputControlMapping.Range.Positive,
                    IgnoreInitialZeroValue = true
                }
            };
        }

    }

}