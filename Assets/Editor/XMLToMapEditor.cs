using UnityEditor;
using UnityEngine;

namespace sumo_unity
{
    [CustomEditor(typeof(XMLToMap))]
    public class XMLToMapEditor : UnityEditor.Editor
    {
        private XMLToMap map;

        private void OnEnable()
        {
            this.map = (XMLToMap)target;

        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            serializedObject.Update();

            //GUILayout.BeginHorizontal();
            //EditorGUILayout.PropertyField(serializedObject.FindProperty("ApiKey"));
            //if (GUILayout.Button("Get an API key", EditorStyles.miniButtonRight))
            //{
            //    Application.OpenURL("https://developers.nextzen.org/");
            //}
            //GUILayout.EndHorizontal();

            //EditorGUILayout.PropertyField(serializedObject.FindProperty("path"), true);

            //EditorGUILayout.PropertyField(serializedObject.FindProperty("Area"), true);

            //EditorGUILayout.PropertyField(serializedObject.FindProperty("UnitsPerMeter"));

            //EditorGUILayout.PropertyField(serializedObject.FindProperty("RegionName"));


            //// EditorGUILayout.PropertyField(serializedObject.FindProperty("GroupOptions"));

            //EditorGUILayout.PropertyField(serializedObject.FindProperty("GameObjectOptions"), true);

            //bool valid = map.IsValid();

            //EditorConfig.SetColor(valid ?
            //    EditorConfig.DownloadButtonEnabledColor :
            //    EditorConfig.DownloadButtonDisabledColor);

            if (GUILayout.Button("Generate"))
            {
                map.LoadXMLFile();
            }

            //if (map.HasPendingTasks())
            //{
            //    // Go through another OnInspectorGUI cycle
            //    Repaint();

            //    if (map.FinishedRunningTasks())
            //    {
            //        map.GenerateSceneGraph();
            //    }
            //}

            //EditorConfig.ResetColor();

            serializedObject.ApplyModifiedProperties();
        }
    }
}