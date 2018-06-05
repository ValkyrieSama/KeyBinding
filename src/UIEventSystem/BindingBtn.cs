using UnityEngine;
using UnityEngine.UI;

namespace ValhallaGames.Unity.UIEventSystem {

    [RequireComponent(typeof(Button))]
    public abstract class BindingBtn<THandle, TKey> : MonoBehaviour {

        private Button button;

        [SerializeField]
        private THandle handle = default(THandle);

        private UIManager<THandle, TKey> manager;

        public THandle Handle {
            get { return handle; }
        }

        /// <summary>
        ///     Get the button component and bind the onclick event.
        /// </summary>
        private void Start() {
            manager = (UIManager<THandle, TKey>) FindObjectOfType(typeof(UIManager<THandle, TKey>));
            button = GetComponent<Button>();
            button.onClick.AddListener(() => { manager.ListenToKey(handle); });
        }

        /// <summary>
        ///     Sets the name of the key used for this handle.
        /// </summary>
        /// <param name="key">Key.</param>
        public void SetKeyName(string key) {
            GetComponentInChildren<Text>().text = key;
        }

    }

}