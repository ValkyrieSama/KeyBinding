using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    [AutoDiscover]
    public class PlayStation3AndroidProfile : UnityInputDeviceProfile {

        public PlayStation3AndroidProfile() {
            Name = "PlayStation 3 Controller";
            Meta = "PlayStation 3 Controller on Android";

            SupportedPlatforms = new[] {
                "Android"
            };

            JoystickNames = new[] {
                "", // Yes, really.
                "PLAYSTATION(R)3 Controller",
                "SHENGHIC 2009/0708ZXW-V1Inc. PLAYSTATION(R)3Conteroller", // Not a typo.
                "Sony PLAYSTATION(R)3 Controller"
            };

            LastResortRegex = "PLAYSTATION(R)3";

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "Cross",
                    Target = InputControlTypes.Action1,
                    Source = Button2
                },
                new InputControlMapping {
                    Handle = "Circle",
                    Target = InputControlTypes.Action2,
                    Source = Button3
                },
                new InputControlMapping {
                    Handle = "Square",
                    Target = InputControlTypes.Action3,
                    Source = Button0
                },
                new InputControlMapping {
                    Handle = "Triangle",
                    Target = InputControlTypes.Action4,
                    Source = Button1
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
                },
                new InputControlMapping {
                    Handle = "Start",
                    Target = InputControlTypes.Start,
                    Source = Button10
                },
                new InputControlMapping {
                    Handle = "System",
                    Target = InputControlTypes.System,
                    Source = KeyCodeButton(KeyCode.Menu)
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
                    TargetRange = InputControlMapping.Range.Negative,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
                    Source = Analog5,
                    SourceRange = InputControlMapping.Range.Positive,
                    TargetRange = InputControlMapping.Range.Positive
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