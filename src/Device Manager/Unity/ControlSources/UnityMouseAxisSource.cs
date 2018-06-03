using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public class UnityMouseAxisSource : IInputControlSource {

        private string mouseAxisQuery;

        public UnityMouseAxisSource(string axis) { mouseAxisQuery = "mouse " + axis; }

        public float GetValue(InputDevice inputDevice) { return Input.GetAxisRaw(mouseAxisQuery); }

        public bool GetState(InputDevice inputDevice) { return !Mathf.Approximately(GetValue(inputDevice), 0.0f); }

    }

}