using UnityEngine;

namespace ValhallaGames.Unity.Multiplayer {

    public interface IPlayer {

        Color Color { get; set; }

        int JoystickId { get; set; }

        void Destroy();
        void Enable();
        void Disable();

    }

}