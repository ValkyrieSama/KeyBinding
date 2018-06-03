using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public abstract class DeviceTracker : MonoBehaviour {
        
        public static ReadOnlyCollection<InputDevice> Devices;
        public static event Action<InputDevice> OnDeviceAttached, OnDeviceDetached, OnActiveDeviceChanged;

        private static InputDevice activeDevice = InputDevice.Null;
        private static List<InputDevice> devices = new List<InputDevice>();

        /// <summary>
        /// Gets the default active device.
        /// </summary>
        /// <value>The default active device.</value>
        /// <remarks>Use mainly for single player games with one controller</remarks>
        public static InputDevice DefaultActiveDevice {
            get { return devices.Count > 0 ? devices[0] : InputDevice.Null; }
        }

        /// <summary>
        /// Gets the last device that updated.
        /// </summary>
        /// <value>The active device.</value>
        public static InputDevice ActiveDevice {
            get { return activeDevice ?? InputDevice.Null; }

            private set { activeDevice = value ?? InputDevice.Null; }
        }

        public static void AttachDevice(InputDevice device) {
            if (!device.IsSupportedOnThisPlatform) return;

            devices.Add(device);
            devices.Sort((d1, d2) => d1.SortOrder.CompareTo(d2.SortOrder));

            OnDeviceAttached?.Invoke(device);

            if (ActiveDevice == InputDevice.Null) ActiveDevice = device;
        }

        public static void DetachDevice(InputDevice device) {
            devices.Remove(device);
            devices.Sort((d1, d2) => d1.SortOrder.CompareTo(d2.SortOrder));

            if (ActiveDevice == device) ActiveDevice = InputDevice.Null;

            OnDeviceDetached?.Invoke(device);
        }

        public static void ActiveDeviceChanged(InputDevice device) {
            OnActiveDeviceChanged?.Invoke(device);
        }

        public static void Setup() {
            devices.Clear();
            activeDevice = InputDevice.Null;

            Devices = new ReadOnlyCollection<InputDevice>(devices);
        }

		public static void Reset() {
            OnActiveDeviceChanged = null;
            OnDeviceAttached = null;
            OnDeviceDetached = null;

            devices.Clear();
            activeDevice = InputDevice.Null;
		}

        public static void UpdateActiveDevice() {
            var lastActiveDevice = ActiveDevice;

            foreach (var device in Devices)
                if (ActiveDevice == InputDevice.Null || device.LastChangedAfter(ActiveDevice)) ActiveDevice = device;

            if (lastActiveDevice != ActiveDevice) OnActiveDeviceChanged?.Invoke(ActiveDevice);
        }
	}
}
