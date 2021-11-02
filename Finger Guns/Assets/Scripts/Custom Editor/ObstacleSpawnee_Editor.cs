using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(ObstacleSpawnee))]
public class ObstacleSpawnee_Editor : Editor
{
    private SerializedProperty hasMaxLifetime;
    private SerializedProperty timeUntilDestroyed;

    void OnEnable()
    {
        hasMaxLifetime = serializedObject.FindProperty("_hasMaxLifetime");
        timeUntilDestroyed = serializedObject.FindProperty("_timeUntilDestroyed");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Lifetime", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        hasMaxLifetime.boolValue = EditorGUILayout.Toggle("Has Max Lifetime", hasMaxLifetime.boolValue);
        if (hasMaxLifetime.boolValue)
            timeUntilDestroyed.floatValue = EditorGUILayout.FloatField("Time Until Destroyed", timeUntilDestroyed.floatValue);
        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
