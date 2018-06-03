using System.Collections.Generic;
using UnityEngine;
using ValhallaGames.Unity.DeviceDetection;
using ValhallaGames.Unity.Utility;

namespace ValhallaGames.Unity.Multiplayer {

    public class MultiplayerManager : Manager {

        [SerializeField]
        private List<Color> colors = new List<Color> {
            Colors.BelizeHole,
            Colors.Pomegranate,
            Colors.Nephritis,
            Colors.Orange
        };

        [SerializeField]
        private Color defaultColor = Colors.Clouds;

        [SerializeField]
        private bool destroyPlayerOnDisconnect = false, createPlayersOnLoad = false;

        [SerializeField]
        private int minPlayers = 1, maxPlayers = 4;

        [SerializeField]
        private GameObject defaultPlayerPrefab = null;

        [SerializeField]
        private List<GameObject> playerPrefabs = new List<GameObject>();

        [SerializeField]
        private GameObject playerParent = null;

        [SerializeField]
        private List<GameObject> players = new List<GameObject>();

        public int MinPlayers {
            get { return minPlayers; }
        }

        public int MaxPlayers {
            get { return maxPlayers; }
        }

        public List<GameObject> Players {
            get { return players; }
            set { players = value; }
        }

        protected virtual void Awake() {
            if(createPlayersOnLoad) {
                DeviceTracker.OnDeviceAttached += OnDeviceAttached;
                DeviceTracker.OnDeviceDetached += OnDeviceDetached;
            }
        }

        private void BindJoystick() {
            foreach(var player in players) {
                foreach (UnityInputDevice device in DeviceManager.Devices) {
                    if (!PlayerExist(device.JoystickId))
                        player.GetComponent<IPlayer>().JoystickId = device.JoystickId;
                }
            }
        }

        protected virtual void Start() {
            if(createPlayersOnLoad)
                InitPlayers();
            else {
                BindJoystick();
                DeviceTracker.OnDeviceAttached += OnDeviceAttached;
                DeviceTracker.OnDeviceDetached += OnDeviceDetached;
            }
        }

        public void AddPlayer(int joystickId) {
            if (players.Count >= maxPlayers) {
                EnableExistingPlayer(joystickId);
                return;
            }

            if (isDebugMode) 
                Debug.Log("Adding new player : JoystickId " + joystickId);

            CreatePlayer(joystickId);
        }

        public void EnablePlayer(int joystickId) {
            if (isDebugMode) 
                Debug.Log("Enabling player : JoystickId " + joystickId);

            FindPlayer(joystickId).Enable();
        }

        public void DisablePlayer(int joystickId) {
            if (isDebugMode) 
                Debug.Log("Disabling player : JoystickId " + joystickId);

            FindPlayer(joystickId).Disable();
        }

        public void RemovePlayer(int joystickId) {
            if (isDebugMode) 
                Debug.Log("Removing player : JoystickId " + joystickId);
            
            FindPlayer(joystickId).Destroy();
            players.RemoveAll(x => x.GetComponent<IPlayer>().JoystickId == joystickId);
        }

        private IPlayer FindPlayer(int joystickId) {
            foreach (var player in players) {
                var playerInterface = player.GetComponent<IPlayer>();

                if (playerInterface.JoystickId == joystickId) 
                    return playerInterface;
            }
            return null;
        }

        public bool PlayerExist(int joystickId) {
            foreach (var player in players) 
                if (player.GetComponent<IPlayer>().JoystickId == joystickId) 
                    return true;
            return false;
        }

        public Color GetColor(int index) {
            if (colors.Count > index) 
                return colors[index];
            return defaultColor;
        }

        public bool MinPlayerReached() { return players.Count >= minPlayers && players.Count <= maxPlayers; }

        private void InitPlayers() {
            foreach (var player in players)
                player.GetComponent<IPlayer>().Destroy();

            players.Clear();

            foreach (var device in DeviceManager.Devices)
                AddPlayer(((UnityInputDevice) device).JoystickId);
        }

        private void OnDeviceAttached(InputDevice device) {
            var joystickId = ((UnityInputDevice) device).JoystickId;

            if (isDebugMode) 
                Debug.Log("Joystick " + joystickId + " attached");

            if (destroyPlayerOnDisconnect || !PlayerExist(joystickId))
                AddPlayer(joystickId);
            else
                EnablePlayer(joystickId);
        }

        private void OnDeviceDetached(InputDevice device) {
            var joystickId = ((UnityInputDevice) device).JoystickId;

            if (isDebugMode) 
                Debug.Log("Joystick " + joystickId + " detached");

            if(PlayerExist(joystickId)) {
                if (destroyPlayerOnDisconnect) 
                    RemovePlayer(joystickId);
                else 
                    DisablePlayer(joystickId);
            }
        }

        private void EnableExistingPlayer(int joystickId) {
            foreach (var player in players) {
                var playerInterface = player.GetComponent<IPlayer>();
                if (playerInterface.JoystickId == joystickId) 
                    EnablePlayer(joystickId);
            }
        }

        private void CreatePlayer(int joystickId) {
            var newPlayer = Instantiate(GetPlayerPrefab(players.Count), Vector3.zero, Quaternion.identity);
            newPlayer.GetComponent<IPlayer>().Color = GetColor(players.Count);
            newPlayer.GetComponent<IPlayer>().JoystickId = joystickId;

            if (playerParent == null)
                newPlayer.transform.parent = transform;
            else
                newPlayer.transform.parent = playerParent.transform;
            
            players.Add(newPlayer);
        }

        private GameObject GetPlayerPrefab(int index) {
            if (playerPrefabs.Count > index)
                return playerPrefabs[index];
            return defaultPlayerPrefab;
        }
    }

}