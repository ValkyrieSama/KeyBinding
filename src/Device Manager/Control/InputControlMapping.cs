using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public class InputControlMapping {

        private string handle;

        public bool IgnoreInitialZeroValue { get; set; }
        public bool Invert { get; set; }

        // Raw inputs won't be processed except for scaling (mice and trackpads).
        public bool Raw { get; set; }

        public float Scale { get; set; } = 1.0f;
        public IInputControlSource Source { get; set; }
        public Range SourceRange { get; set; } = Range.Complete;
        public InputControlTypes Target { get; set; }
        public Range TargetRange { get; set; } = Range.Complete;

        public string Handle {
            get { return string.IsNullOrEmpty(handle) ? Target.ToString() : handle; }
            set { handle = value; }
        }

        public bool IsYAxis {
            get {
                return Target == InputControlTypes.LeftStickY ||
                       Target == InputControlTypes.RightStickY;
            }
        }

        public float MapValue(float value) {
            var targetValue = 0.0f;

            if (Raw) targetValue = value * Scale;
            else targetValue = getTargetValueFromRange(value);

            if (isYAxisInverted()) targetValue = -targetValue;

            return targetValue;
        }

        private float getTargetValueFromRange(float value) {
            var scaledValue = Mathf.Clamp(value * Scale, Range.Complete.Minimum, Range.Complete.Maximum);

            if (isOutsideSourceRange(scaledValue)) return 0.0f;

            var sourceValue = Mathf.InverseLerp(SourceRange.Minimum, SourceRange.Maximum, scaledValue);
            return Mathf.Lerp(TargetRange.Minimum, TargetRange.Maximum, sourceValue);
        }

        private bool isOutsideSourceRange(float value) {
            return value < SourceRange.Minimum || value > SourceRange.Maximum;
        }

        private bool isYAxisInverted() { return Invert != (IsYAxis && InputManager.InvertYAxis); }

        public class Range {

            public static Range Complete = new Range {Minimum = -1.0f, Maximum = 1.0f};
            public static Range Positive = new Range {Minimum = 0.0f, Maximum = 1.0f};
            public static Range Negative = new Range {Minimum = -1.0f, Maximum = 0.0f};

            public float Maximum { get; set; }
            public float Minimum { get; set; }
        }

    }

}