using UnityEngine;

namespace ValhallaGames.Unity.ControlEvents.Keyboard {

    public class KeyboardEventManager<THandle> : KeyEventManager<THandle, KeyCode, KeyCode> {

        public override bool WasKeyPressed(KeyCode key) { return Input.GetKeyDown(key); }

        public override bool IsAnalogPressed(KeyCode key) { return Input.GetKey(key); }

        public override KeyCode GetValue(KeyCode key) { return key; }

    }

}