using System.Collections.Generic;
using System.Linq;

namespace ValhallaGames.Unity.KeyBinding {

    public class ControlPreset<THandle, TKey> {

        public Dictionary<THandle, TKey> Controls { get; protected set; }
        public Dictionary<THandle, TKey>[] Analog { get; protected set; }

        public TKey GetKey(THandle handle) {
            var key = GetControl(handle);
            return key.Equals(default(TKey)) ? GetAnalog(handle) : key;
        }

        public TKey GetControl(THandle handle) {
            foreach (var key in Controls) if (key.Key.Equals(handle)) return key.Value;
            return default(TKey);
        }

        public TKey GetAnalog(THandle handle) {
            foreach (var analog in Analog) foreach (var key in analog) if (key.Key.Equals(handle)) return key.Value;
            return default(TKey);
        }

        public Dictionary<THandle, TKey> GetCorrespondingAnalog(THandle handle) {
            foreach (var analog in Analog) if (analog.Any(key => key.Key.Equals(handle))) return analog;
            return new Dictionary<THandle, TKey>();
        }

    }

}