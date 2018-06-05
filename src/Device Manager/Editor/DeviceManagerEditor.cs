using UnityEngine;
using UnityEditor;

namespace ValhallaGames.Unity.DeviceDetection.Editor {

    [CustomEditor(typeof(DeviceManager))]
    public class DeviceManagerEditor : UnityEditor.Editor {

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawDefaultInspector();
            
            if (GUILayout.Button("Create Inputs")) InputManagerHelper.SetupInputManager();

            if (GUILayout.Button("Clear Inputs")) InputManagerHelper.ClearInputs();

            serializedObject.ApplyModifiedProperties();
        }
    }
}