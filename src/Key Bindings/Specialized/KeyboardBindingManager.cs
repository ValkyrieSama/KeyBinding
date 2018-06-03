using UnityEngine;

namespace ValhallaGames.Unity.KeyBinding.Keyboard {

    public abstract class KeyboardBindingManager<THandle> : KeybindingManager<THandle, KeyCode> {

        private const string LEADING = "Keyboard";

        protected override string GetLeadingSaveText() { return LEADING; }

        /// <summary>
        ///     Display the key pressed. Called in Update().
        /// </summary>
        protected override void DebugKeys() {
            foreach (var key in Keys) if (Input.GetKeyDown(key.Value)) Debug.Log(key.Key);
        }

        /// <summary>
        ///     Listens to key change.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public override void ListenToKey(THandle handle) {
            var e = Event.current;
            if (!e.isKey || handle.Equals(default(THandle))) return;

            var key = default(KeyCode);
            if (e.keyCode != NoneKey) key = e.keyCode;

            ChangeKey(handle, key);
            OnKeyUpdate(key);
        }

    }

}