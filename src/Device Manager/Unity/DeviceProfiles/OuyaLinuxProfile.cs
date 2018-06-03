using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    // @cond nodoc
    [AutoDiscover]
    public class OuyaLinuxProfile : UnityInputDeviceProfile {

        public OuyaLinuxProfile() {
            Name = "OUYA Controller";
            Meta = "OUYA Controller on Linux";

            SupportedPlatforms = new[] {
                "Linux"
            };

            JoystickNames = new[] {
                "OUYA Game Controller"
            };

            MaxUnityVersion = new VersionInfo(4, 9);

            LowerDeadZone = 0.3f;

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "O",
                    Target = InputControlTypes.Action1,
                    Source = Button0
                },
                new InputControlMapping {
                    Handle = "A",
                    Target = InputControlTypes.Action2,
                    Source = Button3
                },
                new InputControlMapping {
                    Handle = "U",
                    Target = InputControlTypes.Action3,
                    Source = Button1
                },
                new InputControlMapping {
                    Handle = "Y",
                    Target = InputControlTypes.Action4,
                    Source = Button2
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
                    Source = Button6
                },
                new InputControlMapping {
                    Handle = "Right Stick Button",
                    Target = InputControlTypes.RightStickButton,
                    Source = Button7
                },
                new InputControlMapping {
                    Handle = "System",
                    Target = InputControlTypes.System,
                    Source = KeyCodeButton(KeyCode.Menu)
                },
                new InputControlMapping {
                    Handle = "TouchPad Tap",
                    Target = InputControlTypes.TouchPadTap,
                    Source = MouseButton0
                },
                new InputControlMapping {
                    Handle = "DPad Left",
                    Target = InputControlTypes.DPadLeft,
                    Source = Button10
                },
                new InputControlMapping {
                    Handle = "DPad Right",
                    Target = InputControlTypes.DPadRight,
                    Source = Button11
                },
                new InputControlMapping {
                    Handle = "DPad Up",
                    Target = InputControlTypes.DPadUp,
                    Source = Button8
                },
                new InputControlMapping {
                    Handle = "DPad Down",
                    Target = InputControlTypes.DPadDown,
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
                    Source = Analog3
                },
                new InputControlMapping {
                    Handle = "Right Stick Y",
                    Target = InputControlTypes.RightStickY,
                    Source = Analog4,
                    Invert = true
                },
                new InputControlMapping {
                    Handle = "Left Trigger",
                    Target = InputControlTypes.LeftTrigger,
                    Source = Analog2
                },
                new InputControlMapping {
                    Handle = "Right Trigger",
                    Target = InputControlTypes.RightTrigger,
                    Source = Analog5
                },
                new InputControlMapping {
                    Handle = "TouchPad X Axis",
                    Target = InputControlTypes.TouchPadXAxis,
                    Source = MouseXAxis,
                    Raw = true
                },
                new InputControlMapping {
                    Handle = "TouchPad Y Axis",
                    Target = InputControlTypes.TouchPadYAxis,
                    Source = MouseYAxis,
                    Raw = true
                }
            };
        }

    }

}