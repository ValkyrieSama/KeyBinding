using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public class UnityKeyCodeSource : IInputControlSource {

        private KeyCode[] keyCodeList;

        public UnityKeyCodeSource(params KeyCode[] keyCodeList) { this.keyCodeList = keyCodeList; }

        public float GetValue(InputDevice inputDevice) { return GetState(inputDevice) ? 1.0f : 0.0f; }

        public bool GetState(InputDevice inputDevice) {
            for (var i = 0; i < keyCodeList.Length; i++) if (Input.GetKey(keyCodeList[i])) return true;
            return false;
        }

    }

}