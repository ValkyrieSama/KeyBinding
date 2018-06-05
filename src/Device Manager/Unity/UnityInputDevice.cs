using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public class UnityInputDevice : InputDevice {

        public const int MaxDevices = 10;
        public const int MaxButtons = 20;
        public const int MaxAnalogs = 20;

        public UnityInputDevice(UnityInputDeviceProfile profile, int joystickId) : base(profile.Name) {
            Initialize(profile, joystickId);
        }

        public UnityInputDevice(UnityInputDeviceProfile profile) : base(profile.Name) { Initialize(profile, 0); }

        public int JoystickId { get; private set; }

        public UnityInputDeviceProfile Profile { get; protected set; }

        public override bool IsSupportedOnThisPlatform {
            get { return Profile.IsSupportedOnThisPlatform; }
        }

        public override bool IsKnown {
            get { return Profile.IsKnown; }
        }

        public override void Update(ulong updateTick, float deltaTime) {
            if (Profile == null) return;

            // Preprocess all analog values.
            foreach (var analogMapping in Profile.AnalogMappings) {
                var targetControl = GetControl(analogMapping.Target);

                var analogValue = analogMapping.Source.GetValue(this);

                if (analogMapping.IgnoreInitialZeroValue && targetControl.IsOnZeroTick &&
                    Mathf.Abs(analogValue) < Mathf.Epsilon) {
                    targetControl.RawValue = null;
                    targetControl.PreValue = null;
                } else {
                    var mappedValue = analogMapping.MapValue(analogValue);

                    if (analogMapping.Raw) targetControl.RawValue = Combine(targetControl.RawValue, mappedValue);
                    else targetControl.PreValue = Combine(targetControl.PreValue, mappedValue);
                }
            }

            // Buttons are easy: just update the control state.
            foreach (var buttonMapping in Profile.ButtonMappings) {
                var buttonState = buttonMapping.Source.GetState(this);

                UpdateWithState(buttonMapping.Target, buttonState, updateTick);
            }
        }

        public bool IsConfiguredWith(UnityInputDeviceProfile deviceProfile, int joystickId) {
            return Profile == deviceProfile && JoystickId == joystickId;
        }

        private void Initialize(UnityInputDeviceProfile profile, int joystickId) {
            Profile = profile;
            Meta = Profile.Meta;

            foreach (var analogMapping in Profile.AnalogMappings) {
                var analogControl = AddControl(analogMapping.Target, analogMapping.Handle);

                analogControl.Sensitivity = Profile.Sensitivity;
                analogControl.UpperDeadZone = Profile.UpperDeadZone;
                analogControl.LowerDeadZone = Profile.LowerDeadZone;
            }

            foreach (var buttonMapping in Profile.ButtonMappings)
                AddControl(buttonMapping.Target, buttonMapping.Handle);

            JoystickId = joystickId;

            if (joystickId == 0) return;

            SortOrder = 100 + joystickId;
            Meta += " [id: " + joystickId + "]";
        }

        private static float Combine(float? value1, float value2) {
            if (value1.HasValue) return Mathf.Abs(value1.Value) > Mathf.Abs(value2) ? value1.Value : value2;
            return value2;
        }

    }

}