using System;
using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    [Serializable]
    public class InputControl {

        internal static readonly InputControl Null = new InputControl("NullInputControl");
        internal float? RawValue, PreValue;

        [SerializeField]
        private float sensitivity = 1.0f, lowerDeadZone, upperDeadZone = 1.0f;

        private InputControlState thisState, lastState, tempState;
        private ulong zeroTick;

        private InputControl(string handle) { Handle = handle; }

        public InputControl(string handle, InputControlTypes target) {
            Handle = handle;
            Target = target;
            IsButton = isButton(target);
        }

        public float Sensitivity {
            get { return sensitivity; }
            internal set { sensitivity = value; }
        }

        public float LowerDeadZone {
            get { return lowerDeadZone; }
            internal set { lowerDeadZone = value; }
        }

        public float UpperDeadZone {
            get { return upperDeadZone; }
            internal set { upperDeadZone = value; }
        }

        public bool IsButton { get; internal set; }
        public string Handle { get; internal set; }
        public ulong UpdateTick { get; internal set; }
        public InputControlTypes Target { get; internal set; }

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
            get { return thisState; }
        }

        public bool WasPressed {
            get { return thisState && !lastState; }
        }

        public bool WasReleased {
            get { return !thisState && lastState; }
        }

        public bool IsNull {
            get { return this == Null; }
        }

        public bool IsNotNull {
            get { return this != Null; }
        }

        public InputControlTypes? Obverse {
            get {
                switch (Target) {
                    case InputControlTypes.LeftStickX: return InputControlTypes.LeftStickY;
                    case InputControlTypes.LeftStickY: return InputControlTypes.LeftStickX;
                    case InputControlTypes.RightStickX: return InputControlTypes.RightStickY;
                    case InputControlTypes.RightStickY: return InputControlTypes.RightStickX;
                    default: return null;
                }
            }
        }

        internal bool IsOnZeroTick {
            get { return UpdateTick == zeroTick; }
        }

        internal void PreUpdate(ulong updateTick) {
            RawValue = null;
            PreValue = null;

            lastState = thisState;
            tempState.Reset();
        }

        internal void UpdateWithState(bool state, ulong updateTick) {
            CheckTickExceptions(updateTick);
            tempState.Set(state || tempState.Pressed);
        }

        internal void UpdateWithValue(float value, ulong updateTick) {
            CheckTickExceptions(updateTick);
            if (Mathf.Abs(value) > Mathf.Abs(tempState.Value)) tempState.Set(value);
        }

        internal void PostUpdate(ulong updateTick) {
            thisState = tempState;
            if (thisState != lastState) UpdateTick = updateTick;
        }

        internal void SetZeroTick() { zeroTick = UpdateTick; }

        public static implicit operator bool(InputControl control) { return control.State; }

        public static implicit operator float(InputControl control) { return control.Value; }

        public override string ToString() { return "[InputControl: Handle=" + Handle + ", Value=" + Value + "]"; }

        private void CheckTickExceptions(ulong updateTick) {
            if (IsNull) throw new InvalidOperationException(Errors.NULL_CONTROLLER_UPDATE);

            if (UpdateTick > updateTick) throw new InvalidOperationException(Errors.TICK_BACKWARD);
        }

        private bool isButton(InputControlTypes target) {
            return target >= InputControlTypes.Action1 && target <= InputControlTypes.Action4 ||
                   target >= InputControlTypes.Button0 && target <= InputControlTypes.Button19;
        }

    }

}