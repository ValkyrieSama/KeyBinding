using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public static class DeadZone {

        public static float ApplyDeadZone(float value, float lowerDeadZone, float upperDeadZone) {
            return Mathf.InverseLerp(lowerDeadZone, upperDeadZone, Mathf.Abs(value)) * Mathf.Sign(value);
        }

        public static Vector2 ApplyCircularDeadZone(Vector2 axisVector, float lowerDeadZone, float upperDeadZone) {
            var magnitude = Mathf.InverseLerp(lowerDeadZone, upperDeadZone, axisVector.magnitude);
            return axisVector.normalized * magnitude;
        }

        public static Vector2 ApplyCircularDeadZone(float axisX, float axisY, float lowerDeadZone, float upperDeadZone) {
            return ApplyCircularDeadZone(new Vector2(axisX, axisY), lowerDeadZone, upperDeadZone);
        }

    }

}