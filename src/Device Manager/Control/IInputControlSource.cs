namespace ValhallaGames.Unity.DeviceDetection {

    public interface IInputControlSource {

        float GetValue(InputDevice inputDevice);
        bool GetState(InputDevice inputDevice);

    }

}