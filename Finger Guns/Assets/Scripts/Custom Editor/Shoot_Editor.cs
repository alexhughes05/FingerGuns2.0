//using UnityEditor;
//using UnityEngine;

//#if UNITY_EDITOR
//[CustomEditor(typeof(Shoot))]
//public class Shoot_Editor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector(); // for other non-HideInInspector fields
//        serializedObject.Update();
//        EditorGUILayout.Space();
//        SerializedProperty hasAnimation = serializedObject.FindProperty("hasAnimation");
//        if (hasAnimation.boolValue)
//        {
//            using (new EditorGUI.IndentLevelScope())
//            {
//                EditorGUILayout.PropertyField(serializedObject.FindProperty("animParamAction"), new GUIContent("AnimatorParameterSO"));
//            }
//        }

//        serializedObject.ApplyModifiedProperties();
//    }
//}
//#endif