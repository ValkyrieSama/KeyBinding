using System.Collections.Generic;

namespace ValhallaGames.Unity.DeviceDetection {

    public class InputDeviceManager {

        protected List<InputDevice> Devices = new List<InputDevice>();

        public virtual void Update(ulong updateTick, float deltaTime) { }

    }

}