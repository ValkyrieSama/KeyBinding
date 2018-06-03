using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public class UnityGyroAxisSource : IInputControlSource {

        public enum GyroAxis {

            X = 0,
            Y = 1

        }

        private static Quaternion zeroAttitude;
        private int axis;

        public UnityGyroAxisSource(GyroAxis axis) {
            this.axis = (int) axis;
            Calibrate();
        }

        public float GetValue(InputDevice inputDevice) { return GetAxis()[axis]; }

        public bool GetState(InputDevice inputDevice) { return !Mathf.Approximately(GetValue(inputDevice), 0.0f); }

        private static Quaternion GetAttitude() { return Quaternion.Inverse(zeroAttitude) * Input.gyro.attitude; }

        private static Vector3 GetAxis() {
            var gv = GetAttitude() * Vector3.forward;
            var gx = ApplyDeadZone(Mathf.Clamp(gv.x, -1.0f, 1.0f));
            var gy = ApplyDeadZone(Mathf.Clamp(gv.y, -1.0f, 1.0f));
            return new Vector3(gx, gy);
        }

        private static float ApplyDeadZone(float value) {
            return Mathf.InverseLerp(0.05f, 1.0f, Mathf.Abs(value)) * Mathf.Sign(value);
        }

        public static void Calibrate() { zeroAttitude = Input.gyro.attitude; }

    }

}