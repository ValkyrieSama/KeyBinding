namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    [AutoDiscover]
    public class ExecutionerXProfile : UnityInputDeviceProfile {

        public ExecutionerXProfile() {
            Name = "Executioner X Controller";
            Meta = "Executioner X Controller";

            SupportedPlatforms = new[] {
                "Windows",
                "OS X"
            };

            JoystickNames = new[] {
                "Zeroplus PS Vibration Feedback Converter",
                "Zeroplus PS Vibration Feedback Converter "
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
                    Source = Button6
                },
                new InputControlMapping {
                    Handle = "Right Bumper",
                    Target = InputControlTypes.RightBumper,
                    Source = Button7
                },
                new InputControlMapping {
                    Handle = "Start",
                    Target = InputControlTypes.Start,
                    Source = Button11
                },
                new InputControlMapping {
                    Handle = "Options",
                    Target = InputControlTypes.Select,
                    Source = Button8
                },
                new InputControlMapping {
                    Handle = "Left Trigger",
                    Target = InputControlTypes.LeftTrigger,
                    Source = Button4
                },
                new InputControlMapping {
                    Handle = "Right Trigger",
                    Target = InputControlTypes.RightTrigger,
                    Source = Button5
                },
                new InputControlMapping {
                    Handle = "Left Stick Button",
                    Target = InputControlTypes.LeftStickButton,
                    Source = Button9
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
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Analog7,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive
                },
                new InputControlMapping {
                    Handle = "DPad Up",
                    Target = InputControlTypes.DPadUp,
                    Source = Analog7,
                    SourceRange = InputControlMapping.Range.Negative,
                    TargetRange = InputControlMapping.Range.Negative,
                    Invert = true
                }
            };
        }

    }

}