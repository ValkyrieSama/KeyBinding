using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection {

    public sealed class AutoDiscover : Attribute { }

    public class UnityInputDeviceProfile {

        private static HashSet<Type> hideList = new HashSet<Type>();
        protected string[] JoystickNames;
        protected string[] JoystickRegex;

        protected string LastResortRegex;
        private float lowerDeadZone;

        private float sensitivity;

        protected string[] SupportedPlatforms;
        private float upperDeadZone;

        public UnityInputDeviceProfile() {
            Name = "";
            Meta = "";

            sensitivity = 1.0f;
            lowerDeadZone = 0.2f;
            upperDeadZone = 0.9f;

            AnalogMappings = new InputControlMapping[0];
            ButtonMappings = new InputControlMapping[0];

            MinUnityVersion = new VersionInfo(3);
            MaxUnityVersion = new VersionInfo(9999);
        }

        public string Name { get; protected set; }
        public string Meta { get; protected set; }

        public InputControlMapping[] AnalogMappings { get; protected set; }
        public InputControlMapping[] ButtonMappings { get; protected set; }

        public VersionInfo MinUnityVersion { get; protected set; }
        public VersionInfo MaxUnityVersion { get; protected set; }

        public float Sensitivity {
            get { return sensitivity; }
            protected set { sensitivity = Mathf.Clamp01(value); }
        }

        public float LowerDeadZone {
            get { return lowerDeadZone; }
            protected set { lowerDeadZone = Mathf.Clamp01(value); }
        }

        public float UpperDeadZone {
            get { return upperDeadZone; }
            protected set { upperDeadZone = Mathf.Clamp01(value); }
        }

        public bool IsSupportedOnThisPlatform {
            get {
                //if (!IsSupportedOnThisVersionOfUnity) return false;

                if (SupportedPlatforms == null || SupportedPlatforms.Length == 0) return true;

                return SupportedPlatforms.Any(platform => InputManager.Platform.Contains(platform.ToUpper()));
            }
        }

        public bool IsSupportedOnThisVersionOfUnity {
            get {
                var unityVersion = VersionInfo.UnityVersion();
                return unityVersion >= MinUnityVersion && unityVersion <= MaxUnityVersion;
            }
        }

        public bool IsJoystick {
            get {
                return LastResortRegex != null ||
                       JoystickNames != null && JoystickNames.Length > 0 ||
                       JoystickRegex != null && JoystickRegex.Length > 0;
            }
        }

        public bool IsNotJoystick {
            get { return !IsJoystick; }
        }

        public bool IsHidden {
            get { return hideList.Contains(GetType()); }
        }

        public virtual bool IsKnown {
            get { return true; }
        }

        public int AnalogCount {
            get { return AnalogMappings.Length; }
        }

        public int ButtonCount {
            get { return ButtonMappings.Length; }
        }

        public bool HasJoystickName(string joystickName) {
            if (IsNotJoystick) return false;

            if (JoystickNames != null && JoystickNames.Contains(joystickName, StringComparer.OrdinalIgnoreCase)) return true;

            return JoystickRegex != null &&
                   JoystickRegex.Any(t => Regex.IsMatch(joystickName, t, RegexOptions.IgnoreCase));
        }

        public bool HasLastResortRegex(string joystickName) {
            if (IsNotJoystick || LastResortRegex == null) return false;

            return Regex.IsMatch(joystickName, LastResortRegex, RegexOptions.IgnoreCase);
        }

        public bool HasJoystickOrRegexName(string joystickName) {
            return HasJoystickName(joystickName) || HasLastResortRegex(joystickName);
        }

        public static void Hide(Type type) { hideList.Add(type); }

        #region InputControlSource Helpers

        protected static IInputControlSource Button(int index) { return new UnityButtonSource(index); }

        protected static IInputControlSource Analog(int index) { return new UnityAnalogSource(index); }

        protected static IInputControlSource KeyCodeButton(params KeyCode[] keyCodeList) {
            return new UnityKeyCodeSource(keyCodeList);
        }

        protected static IInputControlSource KeyCodeComboButton(params KeyCode[] keyCodeList) {
            return new UnityKeyCodeComboSource(keyCodeList);
        }

        protected static IInputControlSource KeyCodeAxis(KeyCode negativeKeyCode, KeyCode positiveKeyCode) {
            return new UnityKeyCodeAxisSource(negativeKeyCode, positiveKeyCode);
        }

        protected static IInputControlSource Button0 = Button(0);
        protected static IInputControlSource Button1 = Button(1);
        protected static IInputControlSource Button2 = Button(2);
        protected static IInputControlSource Button3 = Button(3);
        protected static IInputControlSource Button4 = Button(4);
        protected static IInputControlSource Button5 = Button(5);
        protected static IInputControlSource Button6 = Button(6);
        protected static IInputControlSource Button7 = Button(7);
        protected static IInputControlSource Button8 = Button(8);
        protected static IInputControlSource Button9 = Button(9);
        protected static IInputControlSource Button10 = Button(10);
        protected static IInputControlSource Button11 = Button(11);
        protected static IInputControlSource Button12 = Button(12);
        protected static IInputControlSource Button13 = Button(13);
        protected static IInputControlSource Button14 = Button(14);
        protected static IInputControlSource Button15 = Button(15);
        protected static IInputControlSource Button16 = Button(16);
        protected static IInputControlSource Button17 = Button(17);
        protected static IInputControlSource Button18 = Button(18);
        protected static IInputControlSource Button19 = Button(19);

        protected static IInputControlSource Analog0 = Analog(0);
        protected static IInputControlSource Analog1 = Analog(1);
        protected static IInputControlSource Analog2 = Analog(2);
        protected static IInputControlSource Analog3 = Analog(3);
        protected static IInputControlSource Analog4 = Analog(4);
        protected static IInputControlSource Analog5 = Analog(5);
        protected static IInputControlSource Analog6 = Analog(6);
        protected static IInputControlSource Analog7 = Analog(7);
        protected static IInputControlSource Analog8 = Analog(8);
        protected static IInputControlSource Analog9 = Analog(9);
        protected static IInputControlSource Analog10 = Analog(10);
        protected static IInputControlSource Analog11 = Analog(11);
        protected static IInputControlSource Analog12 = Analog(12);
        protected static IInputControlSource Analog13 = Analog(13);
        protected static IInputControlSource Analog14 = Analog(14);
        protected static IInputControlSource Analog15 = Analog(15);
        protected static IInputControlSource Analog16 = Analog(16);
        protected static IInputControlSource Analog17 = Analog(17);
        protected static IInputControlSource Analog18 = Analog(18);
        protected static IInputControlSource Analog19 = Analog(19);

        protected static IInputControlSource MouseButton0 = new UnityMouseButtonSource(0);
        protected static IInputControlSource MouseButton1 = new UnityMouseButtonSource(1);
        protected static IInputControlSource MouseButton2 = new UnityMouseButtonSource(2);

        protected static IInputControlSource MouseXAxis = new UnityMouseAxisSource("x");
        protected static IInputControlSource MouseYAxis = new UnityMouseAxisSource("y");
        protected static IInputControlSource MouseScrollWheel = new UnityMouseAxisSource("z");

        #endregion

    }

}