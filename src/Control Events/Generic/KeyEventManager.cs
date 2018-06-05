using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using ValhallaGames.Unity.Utility;
using ValhallaGames.Unity.KeyBinding;

namespace ValhallaGames.Unity.ControlEvents {

    public abstract class KeyEventManager<THandle, TKey, TActionReturn> : Manager {

        private KeybindingManager<THandle, TKey> keybindingManager;

        public Dictionary<THandle, KeyEvent> KeyControls { get; protected set; }
        public List<Dictionary<THandle, AnalogEvent>> AnalogControls { get; protected set; }

        public abstract bool WasKeyPressed(TKey key);
        public abstract bool IsAnalogPressed(TKey key);

        public abstract TActionReturn GetValue(TKey key);

        public void AddKeyEvent(THandle handle, UnityAction<TActionReturn> call) {
            foreach (var key in KeyControls) {
                if (key.Key.Equals(handle))
                    key.Value.AddListener(call);
            }
        }

        public void AddAnalogEvent(THandle handle, UnityAction<ICollection<TActionReturn>> call) {
            foreach (var analogs in AnalogControls) {
                foreach (var analog in analogs)
                    if (analog.Key.Equals(handle))
                        analog.Value.AddListener(call);
            }
        }

        protected virtual void Awake() {
            keybindingManager = FindObjectOfType<KeybindingManager<THandle, TKey>>();
            if (keybindingManager == null)
                Debug.LogError("KeybindingManager of type <" + typeof(THandle) + "," + typeof(TKey) + "> missing in scene.");
            InitControls();
            if (isDebugMode) EnableDebug();
        }

        protected virtual void Update() {
            CheckKeyControls();
            CheckAnalogControls();
        }

        private void CheckKeyControls() {
            if(KeyControls != null) {
                foreach (var control in KeyControls) {
                    var key = keybindingManager.GetKey(control.Key);
                    if (WasKeyPressed(key)) control.Value.Invoke(GetValue(key));
                }
            }
        }

        private void CheckAnalogControls() {
            foreach (var analogs in AnalogControls) {
                var allAnalogs = analogs;
                foreach (var analog in analogs) {
                    var key = keybindingManager.GetKey(analog.Key);

                    if (!IsAnalogPressed(key)) 
                        continue;

                    analog.Value.Invoke(allAnalogs.Select(pair => {
                        var pairKey = keybindingManager.GetKey(pair.Key);
                        return GetValue(pairKey);
                    }).ToList());
                    break;
                }
            }
        }

        private void EnableDebug() {
            DebugKeyControls();
            DebugAnalogsControls();
        }

        private void DebugKeyControls() {
            foreach (var control in KeyControls) {
                var handle = control.Key;
                AddKeyEvent(handle, key => DebugKey(handle));
            }
        }

        private static void DebugKey(THandle handle) { Debug.Log(handle + " was pressed"); }

        private void DebugAnalogsControls() {
            foreach (var analogs in AnalogControls) {
                var allAnalogs = analogs;
                foreach (var analog in analogs)
                    AddAnalogEvent(analog.Key, key => DebugAnalogs(allAnalogs.Select(pair => pair.Key).ToArray()));
            }
        }

        private static void DebugAnalogs(ICollection<THandle> handles) {
            Debug.Log(handles.Count + " were triggered.");
        }

        private void InitControls() {
            var defaultPreset = keybindingManager.DefaultPreset;
            InitKeyControls(defaultPreset);
            InitAnalogControls(defaultPreset);
        }

        private void InitKeyControls(ControlPreset<THandle, TKey> preset) {
            KeyControls = new Dictionary<THandle, KeyEvent>();
            foreach (var control in preset.Controls) KeyControls.Add(control.Key, new KeyEvent());
        }

        private void InitAnalogControls(ControlPreset<THandle, TKey> preset) {
            AnalogControls = new List<Dictionary<THandle, AnalogEvent>>();
            foreach (var analogs in preset.Analog) {
                var analogArray = analogs.ToDictionary(analog => analog.Key, analog => new AnalogEvent());
                AnalogControls.Add(analogArray);
            }
        }

        [Serializable]
        public class KeyEvent : UnityEvent<TActionReturn> { }

        [Serializable]
        public class AnalogEvent : UnityEvent<ICollection<TActionReturn>> { }

    }

}