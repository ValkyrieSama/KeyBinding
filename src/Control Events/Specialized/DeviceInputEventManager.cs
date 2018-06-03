using ValhallaGames.Unity.DeviceDetection;

namespace ValhallaGames.Unity.ControlEvents.Device {

    public class DeviceInputEventManager<THandle> : KeyEventManager<THandle, InputControlTypes, InputControl> {

        public int JoystickId { get; set; }

        public override bool WasKeyPressed(InputControlTypes key) {
            return DeviceManager.GetControl(JoystickId, key).WasPressed;
        }

        public override bool IsAnalogPressed(InputControlTypes key) {
            return DeviceManager.GetControl(JoystickId, key).IsPressed;
        }

        public override InputControl GetValue(InputControlTypes key) {
            return DeviceManager.GetControl(JoystickId, key);
        }

    }

}