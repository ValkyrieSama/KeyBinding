using System;
using System.Collections.Generic;
using UnityEngine;
using ValhallaGames.Unity.Utility;

#pragma warning disable 0693

namespace ValhallaGames.Unity.KeyBinding {

    public abstract class KeybindingManager<THandle, TKey> : Manager {

        public delegate void KeyUpdateCallback(TKey key);

        private const string SEPARATOR = "_";

        [SerializeField]
        private bool resetKeysOnLoad = false;
        [SerializeField]
        private TKey noneKey;

        public TKey NoneKey {
            get { return noneKey; }
            set { noneKey = value; }
        }

        public ControlPreset<THandle, TKey> DefaultPreset { get; protected set; }
        public List<ControlPreset<THandle, TKey>> Presets { get; protected set; }

        /// <summary>
        ///     Gets the keys configured in the system. The key is the Handle and the Value is the Control corresponding.
        /// </summary>
        /// <value>The keys.</value>
        public Dictionary<THandle, TKey> Keys { get; private set; }

        protected abstract string GetLeadingSaveText();

        /// <summary>
        ///     Occurs when the key is changed.
        /// </summary>
        public event KeyUpdateCallback KeyUpdatedEvent;

        /// <summary>
        ///     Display the key pressed. Called in Update().
        /// </summary>
        protected abstract void DebugKeys();

        /// <summary>
        ///     Listens to key change.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public abstract void ListenToKey(THandle handle);

        /// <summary>
        ///     Saves the keys in the player prefs.
        /// </summary>
        public void SaveKeys() {
            foreach (var key in Keys) PlayerPrefs.SetString(GetSavedHandle(key.Key), key.Value.ToString());

            PlayerPrefs.Save();
        }

        /// <summary>
        ///     Tries to parse a string in the class type.
        /// </summary>
        /// <returns>The value parsed.</returns>
        /// <param name="value">Value.</param>
        /// <param name="defaultValue">Default value.</param>
        public static T TryParse<T>(string value, T defaultValue) {
            if (!Enum.IsDefined(typeof(T), value)) return defaultValue;

            return (T) Enum.Parse(typeof(T), value);
        }

        /// <summary>
        ///     Gets the key from the handle.
        /// </summary>
        /// <returns>The key.</returns>
        /// <param name="handle">Handle.</param>
        public TKey GetKey(THandle handle) {
            foreach (var key in Keys)
                if (key.Key.Equals(handle))
                    return key.Value;
            return default(TKey);
        }

        /// <summary>
        ///     Raises the key update event.
        /// </summary>
        /// <param name="key">Name.</param>
        public void OnKeyUpdate(TKey key) {
            if (isDebugMode) Debug.Log("New key setted: " + key);
            KeyUpdatedEvent?.Invoke(key);
        }

        /// <summary>
        ///     Load the keys dictionary.
        /// </summary>
        protected virtual void Awake() {
            Keys = new Dictionary<THandle, TKey>();
            LoadKeys();
        }

        /// <summary>
        ///     Debug the keys.
        /// </summary>
        protected virtual void Update() {
            if (isDebugMode) DebugKeys();
        }

        /// <summary>
        ///     Save the keys on application quit.
        /// </summary>
        protected virtual void OnApplicationQuit() {
            SaveKeys();
        }

        /// <summary>
        ///     Changes a key control.
        /// </summary>
        /// <param name="handle">Handle.</param>
        /// <param name="control">Control.</param>
        protected void ChangeKey(THandle handle, TKey control) {
            Keys[handle] = control;
        }

        /// <summary>
        ///     Load the keys from the PlayerPrefs using the handle enum.
        /// </summary>
        private void LoadKeys() {
            foreach (THandle handle in Enum.GetValues(typeof(THandle))) {
                var key = DefaultPreset.GetKey(handle);
                if(!resetKeysOnLoad)
                    key = TryParse(PlayerPrefs.GetString(GetSavedHandle(handle)), key);
                Keys.Add(handle, key);
            }
        }

        private string GetSavedHandle(THandle handle) { return GetLeadingSaveText() + SEPARATOR + handle; }

    }

}