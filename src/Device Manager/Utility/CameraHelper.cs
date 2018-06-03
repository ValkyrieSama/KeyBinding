using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public static class CameraHelper {

        public static bool GameObjectIsCulledOnCurrentCamera(GameObject gameObject) {
            return (UnityEngine.Camera.current.cullingMask & (1 << gameObject.layer)) == 0;
        }

    }

}