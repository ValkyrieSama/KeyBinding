using System;

namespace ValhallaGames.Unity.DeviceDetection {

    public class OneAxisInputControl {

        private InputControlState lastState;

        private InputControlState thisState;

        public ulong UpdateTick { get; private set; }

        public bool State {
            get { return thisState.Pressed; }
        }

        public bool LastState {
            get { return lastState.Pressed; }
        }

        public float Value {
            get { return thisState.Value; }
        }

        public float LastValue {
            get { return lastState.Value; }
        }

        public bool HasChanged {
            get { return thisState != lastState; }
        }

        public bool IsPressed {
            get { return thisState.Pressed; }
        }

        public bool WasPressed {
            get { return thisState && !lastState; }
        }

        public bool WasReleased {
            get { return !thisState && lastState; }
        }

        public void UpdateWithValue(float value, ulong updateTick, float stateThreshold) {
            if (IsTickBackward(updateTick)) throw new InvalidOperationException(Errors.TICK_BACKWARD);

            lastState = thisState;

            thisState.Set(value, stateThreshold);

            if (thisState != lastState) UpdateTick = updateTick;
        }

        public static implicit operator bool(OneAxisInputControl control) { return control.State; }

        public static implicit operator float(OneAxisInputControl control) { return control.Value; }

        private bool IsTickBackward(ulong updateTick) { return UpdateTick > updateTick; }

    }

}