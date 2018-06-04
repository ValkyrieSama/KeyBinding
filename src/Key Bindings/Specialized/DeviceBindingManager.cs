using UnityEngine;
using ValhallaGames.Unity.DeviceDetection;

namespace ValhallaGames.Unity.KeyBinding.Device {

    public abstract class DeviceBindingManager<THandle> : KeybindingManager<THandle, InputControlTypes> {

        private const string LEADING = "Device";

        protected override string GetLeadingSaveText() { return LEADING; }

        /// <summary>
        ///     Display the key pressed. Called in Update().
        /// </summary>
        protected override void DebugKeys() {
            if (DeviceManager.Devices == null || DeviceManager.Devices.Count < 1) return;
            foreach (var key in Keys)
                if (DeviceManager.DefaultActiveDevice.GetControl(key.Value).WasPressed) Debug.Log(key.Key);
        }

        /// <summary>
        ///     Listens to key change.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public override void ListenToKey(THandle handle) {
            if (DeviceManager.Devices == null || DeviceManager.Devices.Count < 1) return;
            var e = DeviceManager.DefaultActiveDevice.AnyControl;
            if (e == InputControl.Null || handle.Equals(default(THandle))) return;

            var key = default(InputControlTypes);
            if (e.Target != NoneKey) key = e.Target;

            ChangeKey(handle, key);
            OnKeyUpdate(key);
        }

        /// <summary>
        /// Get a specific control from a device
        /// </summary>
        /// <returns>The control.</returns>
        /// <param name="joystickId">Joystick identifier.</param>
        /// <param name="handle">Type.</param>
        public InputControl GetControl(int joystickId, THandle handle) {
            return DeviceManager.GetControl(joystickId, GetKey(handle));
        }
    }
}