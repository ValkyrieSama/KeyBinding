﻿using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    [AutoDiscover]
    public class GoogleNexusPlayerRemoteProfile : UnityInputDeviceProfile {

        public GoogleNexusPlayerRemoteProfile() {
            Name = "Google Nexus Player Remote";
            Meta = "Google Nexus Player Remote";

            SupportedPlatforms = new[] {
                "Android"
            };

            JoystickNames = new[] {
                "Google Nexus Remote"
            };

            ButtonMappings = new[] {
                new InputControlMapping {
                    Handle = "A",
                    Target = InputControlTypes.Action1,
                    Source = Button0
                },
                new InputControlMapping {
                    Handle = "Back",
                    Target = InputControlTypes.Back,
                    Source = KeyCodeButton(KeyCode.Escape)
                }
            };

            AnalogMappings = new[] {
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