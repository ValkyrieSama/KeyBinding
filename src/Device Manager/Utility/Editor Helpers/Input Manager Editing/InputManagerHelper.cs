using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ValhallaGames.Unity.DeviceDetection.Editor {

    public abstract class InputManagerHelper : UnityEditor.Editor {

        private static readonly string INPUT_MANAGER_PATH = "ProjectSettings/InputManager.asset";
        private static readonly string AXES = "m_Axes";
        private static readonly string JOYSTICK = "joystick ";
        private static readonly string ANALOG = " analog ";

        public static void ClearInputs() {
            var obj = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(INPUT_MANAGER_PATH)[0]);
            var axesProperty = obj.FindProperty(AXES);
            axesProperty.ClearArray();
            obj.ApplyModifiedProperties();
            CreateDefaultInputs();
        }

        public static void CreateDefaultInputs() {
            var axes = new List<InputAxis> {
                DefaultKeyboardInputAxis.Horizontal,
                DefaultKeyboardInputAxis.Vertical,
                DefaultKeyboardInputAxis.Fire1,
                DefaultKeyboardInputAxis.Fire2,
                DefaultKeyboardInputAxis.Fire3,
                DefaultKeyboardInputAxis.Jump,
                DefaultMouseInputAxis.MouseX,
                DefaultMouseInputAxis.MouseY,
                DefaultMouseInputAxis.MouseScrollWheel,
                DefaultJoystickInputAxis.Horizontal,
                DefaultJoystickInputAxis.Vertical,
                DefaultJoystickInputAxis.Fire1,
                DefaultJoystickInputAxis.Fire2,
                DefaultJoystickInputAxis.Fire3,
                DefaultJoystickInputAxis.Jump,
                DefaultJoystickInputAxis.Submit,
                DefaultKeyboardInputAxis.Submit,
                DefaultJoystickInputAxis.Cancel
            };

            foreach (var axis in axes)
                AddAxis(axis);
        }

        public static void SetupInputManager(int joystickCount = 10, int analogCount = 20) {
            for (int i = 0; i < joystickCount; ++i) {
                for (int j = 0; j < analogCount; ++j) {
                    AddAxis(new InputAxis {
                        name = JOYSTICK + (i + 1) + ANALOG + j,
                        gravity = 0f,
                        dead = 0.001f,
                        sensitivity = 1f,
                        type = AxisType.JoystickAxis,
                        axis = j,
                        joyNum = (i + 1),
                    });
                }
            }
        }

        private static SerializedProperty GetChildProperty(SerializedProperty parent, string name) {
            var child = parent.Copy();
            child.Next(true);
            do {
                if (child.name == name) return child;
            } while (child.Next(false));
            return null;
        }

        private static bool AxisDefined(string axisName) {
            var obj = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(INPUT_MANAGER_PATH)[0]);
            var axesProperty = obj.FindProperty(AXES);

            axesProperty.Next(true);
            axesProperty.Next(true);
            while (axesProperty.Next(false)) {
                SerializedProperty axis = axesProperty.Copy();
                axis.Next(true);
                if (axis.stringValue == axisName) return true;
            }
            return false;
        }

        private static void AddAxis(InputAxis axis) {
            var obj = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(INPUT_MANAGER_PATH)[0]);
            var axesProperty = obj.FindProperty(AXES);

            axesProperty.arraySize++;
            obj.ApplyModifiedProperties();

            var axisProperty = axesProperty.GetArrayElementAtIndex(axesProperty.arraySize - 1);
            GetChildProperty(axisProperty, "m_Name").stringValue = axis.name;
            GetChildProperty(axisProperty, "descriptiveName").stringValue = axis.descriptiveName;
            GetChildProperty(axisProperty, "descriptiveNegativeName").stringValue = axis.descriptiveNegativeName;
            GetChildProperty(axisProperty, "negativeButton").stringValue = axis.negativeButton;
            GetChildProperty(axisProperty, "positiveButton").stringValue = axis.positiveButton;
            GetChildProperty(axisProperty, "altNegativeButton").stringValue = axis.altNegativeButton;
            GetChildProperty(axisProperty, "altPositiveButton").stringValue = axis.altPositiveButton;
            GetChildProperty(axisProperty, "gravity").floatValue = axis.gravity;
            GetChildProperty(axisProperty, "dead").floatValue = axis.dead;
            GetChildProperty(axisProperty, "sensitivity").floatValue = axis.sensitivity;
            GetChildProperty(axisProperty, "snap").boolValue = axis.snap;
            GetChildProperty(axisProperty, "invert").boolValue = axis.invert;
            GetChildProperty(axisProperty, "type").intValue = (int)axis.type;
            GetChildProperty(axisProperty, "axis").intValue = axis.axis;
            GetChildProperty(axisProperty, "joyNum").intValue = axis.joyNum;

            obj.ApplyModifiedProperties();
        }

    }

}