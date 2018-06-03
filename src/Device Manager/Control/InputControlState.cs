using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public struct InputControlState {

        public bool Pressed;
        public float Value;

        public void Reset() {
            Value = 0.0f;
            Pressed = false;
        }

        public void Set(float value) {
            Value = value;
            Pressed = !Mathf.Approximately(value, 0.0f);
        }

        public void Set(float value, float threshold) {
            Pressed = Mathf.Abs(value) > threshold;
            Value = value;
        }

        public void Set(bool state) {
            Pressed = state;
            Value = state ? 1.0f : 0.0f;
        }

        public static implicit operator bool(InputControlState state) { return state.Pressed; }

        public static implicit operator float(InputControlState state) { return state.Value; }

        public static bool operator ==(InputControlState a, InputControlState b) {
            return Mathf.Approximately(a.Value, b.Value);
        }

        public static bool operator !=(InputControlState a, InputControlState b) {
            return !Mathf.Approximately(a.Value, b.Value);
        }

        public override bool Equals(object obj) { return Equals(Value, (InputControlState) obj); }

        public bool Equals(InputControlState obj) { return !Mathf.Approximately(Value, obj.Value); }

        public override int GetHashCode() { return GetHashCode(); }

    }

}