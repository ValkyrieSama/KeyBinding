namespace ValhallaGames.Unity.DeviceDetection {

    // Tested with ADT-1
    // Profile by Artūras 'arturaz' Šlajus <arturas@tinylabproductions.com>
    //
    // @cond nodoc
    [AutoDiscover]
    public class AndroidTVProfile : UnityInputDeviceProfile {

        public AndroidTVProfile() {
            Name = "Android TV Controller";
            Meta = "Android TV Controller on Android TV";

            SupportedPlatforms = new[] {
                "Android"
            };

            JoystickNames = new[] {
                "Gamepad"
            };

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "A",
                    Target = InputControlTypes.Action1,
                    Source = Button0
                },
                new InputControlMapping {
                    Handle = "B",
                    Target = InputControlTypes.Action2,
                    Source = Button1
                },
                new InputControlMapping {
                    Handle = "X",
                    Target = InputControlTypes.Action3,
                    Source = Button2
                },
                new InputControlMapping {
                    Handle = "Y",
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
                    Handle = "Left Stick Button",
                    Target = InputControlTypes.LeftStickButton,
                    Source = Button8
                },
                new InputControlMapping {
                    Handle = "Right Stick Button",
                    Target = InputControlTypes.RightStickButton,
                    Source = Button9
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
                    TargetRange = InputControlMapping.Range.Negative
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Analog5,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "Left Trigger",
                    Target = InputControlTypes.LeftTrigger,
                    Source = Analog6
                },
                new InputControlMapping {
                    Handle = "Right Trigger",
                    Target = InputControlTypes.RightTrigger,
                    Source = Analog7
                }
            };
        }

    }

}