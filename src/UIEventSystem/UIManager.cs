using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ValhallaGames.Unity.Utility;
using ValhallaGames.Unity.KeyBinding;

namespace ValhallaGames.Unity.EventSystem {

    public abstract class UIManager<THandle, TKey> : Manager {

        private BindingBtn<THandle, TKey>[] buttons;

        private BindingBtn<THandle, TKey> currentBtn;
        private THandle currentHandle;

        [SerializeField]
        private KeybindingManager<THandle, TKey> manager;

        private void Start() {
            manager = (KeybindingManager<THandle, TKey>) FindObjectOfType(typeof(KeybindingManager<THandle, TKey>));
            manager.KeyUpdatedEvent += UpdateUI;
            buttons = GetComponentsInChildren<BindingBtn<THandle, TKey>>();
            LoadKeyCode();
        }

        private void OnGUI() { manager.ListenToKey(currentHandle); }

        public void ListenToKey(THandle handle) {
            currentHandle = handle;
            currentBtn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<BindingBtn<THandle, TKey>>();
            currentBtn.GetComponent<Button>().Select();

            var defaultHandle = default(THandle);
            if (defaultHandle != null) currentBtn.SetKeyName(defaultHandle.ToString());
        }

        public void UpdateUI(TKey key) {
            currentHandle = default(THandle);
            currentBtn.SetKeyName(key.ToString());
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
        }

        private void LoadKeyCode() {
            foreach (var button in buttons) {
                var keyName = manager.GetKey(button.Handle).ToString();
                button.SetKeyName(keyName);
            }
        }

    }

}