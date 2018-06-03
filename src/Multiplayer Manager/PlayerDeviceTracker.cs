using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValhallaGames.Unity.Utility;
using ValhallaGames.Unity.DeviceDetection;
using System.Linq;
using System;

namespace ValhallaGames.Unity.Multiplayer {
    
    public class PlayerDeviceTracker : Manager {

        public static event Action<int> OnDeviceAttached, OnDeviceDetached, OnActiveDeviceChanged;

        public static PlayerDeviceTracker Instance { get; private set; }

        protected virtual void Awake() {
            if (Instance == null) 
                Instance = this;
            else if (Instance != this) 
                Destroy(this);
        }

        protected virtual void Start() {
            DeviceTracker.OnDeviceAttached += DeviceAttached;
            DeviceTracker.OnDeviceDetached += DeviceDettached;
            DeviceTracker.OnActiveDeviceChanged += ActiveDeviceChanged;
        }

    	public int GetAvailableJoystickId () {
            foreach(UnityInputDevice device in DeviceTracker.Devices) {
                if(IsAvailable(device.JoystickId))
                    return device.JoystickId;
            }
            return 0;
    	}
    	
        public bool IsAvailable (int joystickId) {
            var players = GetPlayers();
            foreach (var player in players) {
                if (player.JoystickId == joystickId)
                    return false;
            }
            return true;
    	}

        private IPlayer[] GetPlayers() {
            var objects = FindObjectsOfType<MonoBehaviour>();
            return (from a in objects where a.GetType().GetInterfaces().Any(k => k == typeof(IPlayer)) select (IPlayer)a).ToArray();
        }

        private void DeviceAttached(InputDevice device) {
            OnDeviceAttached.Invoke(((UnityInputDevice)device).JoystickId);
        }

        private void DeviceDettached(InputDevice device) {
            OnDeviceDetached.Invoke(((UnityInputDevice)device).JoystickId);
        }

        private void ActiveDeviceChanged(InputDevice device) {
            OnActiveDeviceChanged.Invoke(((UnityInputDevice)device).JoystickId);
        }
    }
}
