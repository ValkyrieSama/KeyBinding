using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public class InputDevice {

        public static readonly InputDevice Null = new InputDevice("NullInputDevice");

        private bool invertYAxis = false;

        public int SortOrder { get; set; } = int.MaxValue;

        public InputDevice(string name) {
            Name = name;
            Meta = "";

            LastChangeTick = 0;

            const int numInputControlTypes = (int) InputControlTypes.Count + 1;
            Controls = new InputControl[numInputControlTypes];

            LeftStick = new TwoAxisInputControl();
            RightStick = new TwoAxisInputControl();
            DPad = new TwoAxisInputControl();
        }

        public string Name { get; protected set; }
        public string Meta { get; protected set; }

        public ulong LastChangeTick { get; protected set; }

        public bool InvertYAxis { 
            get { return invertYAxis; } 
            set { 
                invertYAxis = value; 
                RightStick.InvertYAxis = value; 
            } 
        }

        public InputControl[] Controls { get; protected set; }

        public TwoAxisInputControl LeftStick { get; protected set; }
        public TwoAxisInputControl RightStick { get; protected set; }
        public TwoAxisInputControl DPad { get; protected set; }

        public InputControl LeftStickX {
            get { return GetControl(InputControlTypes.LeftStickX); }
        }

        public InputControl LeftStickY {
            get { return GetControl(InputControlTypes.LeftStickY); }
        }

        public InputControl RightStickX {
            get { return GetControl(InputControlTypes.RightStickX); }
        }

        public InputControl RightStickY {
            get { return GetControl(InputControlTypes.RightStickY); }
        }

        public InputControl DPadUp {
            get { return GetControl(InputControlTypes.DPadUp); }
        }

        public InputControl DPadDown {
            get { return GetControl(InputControlTypes.DPadDown); }
        }

        public InputControl DPadLeft {
            get { return GetControl(InputControlTypes.DPadLeft); }
        }

        public InputControl DPadRight {
            get { return GetControl(InputControlTypes.DPadRight); }
        }

        public InputControl Action1 {
            get { return GetControl(InputControlTypes.Action1); }
        }

        public InputControl Action2 {
            get { return GetControl(InputControlTypes.Action2); }
        }

        public InputControl Action3 {
            get { return GetControl(InputControlTypes.Action3); }
        }

        public InputControl Action4 {
            get { return GetControl(InputControlTypes.Action4); }
        }

        public InputControl LeftTrigger {
            get { return GetControl(InputControlTypes.LeftTrigger); }
        }

        public InputControl RightTrigger {
            get { return GetControl(InputControlTypes.RightTrigger); }
        }

        public InputControl LeftBumper {
            get { return GetControl(InputControlTypes.LeftBumper); }
        }

        public InputControl RightBumper {
            get { return GetControl(InputControlTypes.RightBumper); }
        }

        public InputControl LeftStickButton {
            get { return GetControl(InputControlTypes.LeftStickButton); }
        }

        public InputControl RightStickButton {
            get { return GetControl(InputControlTypes.RightStickButton); }
        }

        public float DPadX {
            get { return DPad.X; }
        }

        public float DPadY {
            get { return DPad.Y; }
        }

        public TwoAxisInputControl Direction {
            get { return DPad.UpdateTick > LeftStick.UpdateTick ? DPad : LeftStick; }
        }

        public virtual bool IsSupportedOnThisPlatform {
            get { return true; }
        }

        public virtual bool IsKnown {
            get { return true; }
        }

        public bool MenuWasPressed {
            get {
                return GetControl(InputControlTypes.Back).WasPressed ||
                       GetControl(InputControlTypes.Start).WasPressed ||
                       GetControl(InputControlTypes.Select).WasPressed ||
                       GetControl(InputControlTypes.System).WasPressed ||
                       GetControl(InputControlTypes.Pause).WasPressed ||
                       GetControl(InputControlTypes.Menu).WasPressed;
            }
        }

        public InputControl AnyButton {
            get {
                foreach (var control in Controls)
                    if (control != null && control.IsButton && control.IsPressed) return control;

                return InputControl.Null;
            }
        }

        public InputControl AnyAnalog {
            get {
                foreach (var control in Controls) if (control != null && IsAnalogPressed(control)) return control;

                return InputControl.Null;
            }
        }

        public InputControl AnyControl {
            get {
                foreach (var control in Controls)
                    if (control != null && (IsAnalogPressed(control) || IsButtonPressed(control))) return control;

                return InputControl.Null;
            }
        }

        public Vector2 DPadVector {
            get {
                var x = DPadLeft.IsPressed ? -DPadLeft.Value : DPadRight.Value;
                var t = DPadUp.IsPressed ? DPadUp.Value : -DPadDown.Value;
                var y = InvertYAxis ? -t : t;
                return new Vector2(x, y).normalized;
            }
        }

        public InputControl GetControl(InputControlTypes inputControlType) {
            var control = Controls[(int) inputControlType];
            return control ?? InputControl.Null;
        }

        public InputControl AddControl(InputControlTypes inputControlType, string handle) {
            var inputControl = new InputControl(handle, inputControlType);
            Controls[(int) inputControlType] = inputControl;
            return inputControl;
        }

        public void UpdateWithState(InputControlTypes inputControlType, bool state, ulong updateTick) {
            GetControl(inputControlType).UpdateWithState(state, updateTick);
        }

        public void UpdateWithValue(InputControlTypes inputControlType, float value, ulong updateTick) {
            GetControl(inputControlType).UpdateWithValue(value, updateTick);
        }

        public void PreUpdate(ulong updateTick, float deltaTime) {
            foreach (var control in Controls) if (control != null) control.PreUpdate(updateTick);
        }

        public virtual void Update(ulong updateTick, float deltaTime) { }

        public void PostUpdate(ulong updateTick, float deltaTime) {
            // Apply post-processing to controls.
            foreach (var control in Controls)
                if (control != null) {
                    if (control.RawValue.HasValue) control.UpdateWithValue(control.RawValue.Value, updateTick);
                    else if (control.PreValue.HasValue)
                        control.UpdateWithValue(ProcessAnalogControlValue(control, deltaTime), updateTick);

                    control.PostUpdate(updateTick);

                    if (control.HasChanged) LastChangeTick = updateTick;
                }

            // Update two-axis controls.
            LeftStick.Update(LeftStickX, LeftStickY, updateTick);
            RightStick.Update(RightStickX, RightStickY, updateTick);

            var dpv = DPadVector;
            DPad.Update(dpv.x, dpv.y, updateTick);
        }

        private float ProcessAnalogControlValue(InputControl control, float deltaTime) {
            if (control.PreValue == null) return 0.0f;

            var analogValue = control.PreValue.Value;

            var obverseTarget = control.Obverse;

            if (obverseTarget.HasValue) {
                var obverseControl = GetControl(obverseTarget.Value);
                if (obverseControl.PreValue.HasValue)
                    analogValue = ApplyCircularDeadZone(analogValue, obverseControl.PreValue.Value,
                        control.LowerDeadZone, control.UpperDeadZone);
                else analogValue = ApplyDeadZone(analogValue, control.LowerDeadZone, control.UpperDeadZone);
            } else { analogValue = ApplyDeadZone(analogValue, control.LowerDeadZone, control.UpperDeadZone); }

            return ApplySmoothing(analogValue, control.LastValue, deltaTime, control.Sensitivity);
        }

        private static float ApplyDeadZone(float value, float lowerDeadZone, float upperDeadZone) {
            return Mathf.InverseLerp(lowerDeadZone, upperDeadZone, Mathf.Abs(value)) * Mathf.Sign(value);
        }

        private static float ApplyCircularDeadZone(float axisValue1, float axisValue2, float lowerDeadZone,
            float upperDeadZone) {
            var axisVector = new Vector2(axisValue1, axisValue2);
            var magnitude = Mathf.InverseLerp(lowerDeadZone, upperDeadZone, axisVector.magnitude);
            return (axisVector.normalized * magnitude).x;
        }

        private static float ApplySmoothing(float thisValue, float lastValue, float deltaTime, float sensitivity) {
            // 1.0f and above is instant (no smoothing).
            if (Mathf.Approximately(sensitivity, 1.0f)) return thisValue;

            // Apply sensitivity (how quickly the value adapts to changes).
            var maxDelta = deltaTime * sensitivity * 100.0f;

            // Snap to zero when changing direction quickly.
            if (Mathf.Sign(lastValue) != Mathf.Sign(thisValue)) lastValue = 0.0f;

            return Mathf.MoveTowards(lastValue, thisValue, maxDelta);
        }

        public bool LastChangedAfter(InputDevice otherDevice) { return LastChangeTick > otherDevice.LastChangeTick; }

        public virtual void Vibrate(float leftMotor, float rightMotor) { }

        public void Vibrate(float intensity) { Vibrate(intensity, intensity); }

        private static bool IsButtonPressed(InputControl control) { return control.IsButton && control.IsPressed; }

        private static bool IsAnalogPressed(InputControl control) {
            return !control.IsButton &&
                   (control.Value < control.Sensitivity / 2 * -1 || control.Value > control.Sensitivity / 2);
        }

    }

}