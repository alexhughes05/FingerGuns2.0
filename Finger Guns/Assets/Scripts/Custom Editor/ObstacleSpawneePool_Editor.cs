using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(ObstacleSpawneePool))]
public class ObstacleSpawneePool_Editor : Editor
{
    private SerializedProperty minSpawnRateInSeconds;
    private SerializedProperty maxSpawnRateInSeconds;
    private SerializedProperty spawnPositionType;
    private SerializedProperty possibleTransformSpawnPoints;
    private SerializedProperty possibleRelativeToScreenSpawnPoints;
    private bool addBtnVal;
    private bool removeBtnVal;
    private Vector2 screenPosVector = Vector2.zero;
    SpawnPositionTypes selectedSpawnPosType;
    SpawnPositionTypes currentSpawnPosType;

    void OnEnable()
    {
        minSpawnRateInSeconds = serializedObject.FindProperty("_minSpawnRateInSeconds");
        maxSpawnRateInSeconds = serializedObject.FindProperty("_maxSpawnRateInSeconds");
        spawnPositionType = serializedObject.FindProperty("_spawnType");
        possibleTransformSpawnPoints = serializedObject.FindProperty("_possibleTransformSpawnPoints");
        possibleRelativeToScreenSpawnPoints = serializedObject.FindProperty("_possibleRelativeSpawnPoints");
        currentSpawnPosType = (SpawnPositionTypes)spawnPositionType.enumValueIndex;
        selectedSpawnPosType = currentSpawnPosType;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();

        serializedObject.Update();

        EditorGUILayout.LabelField("Spawn Time", EditorStyles.boldLabel);
        using (new EditorGUI.IndentLevelScope())
        {
            minSpawnRateInSeconds.floatValue = EditorGUILayout.FloatField("Min Spawn Time:", Mathf.Max(0, minSpawnRateInSeconds.floatValue));
            maxSpawnRateInSeconds.floatValue = EditorGUILayout.FloatField("Max Spawn Time:", Mathf.Max(0, maxSpawnRateInSeconds.floatValue));
        }

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Spawn Position Type:", EditorStyles.boldLabel);
        if (selectedSpawnPosType != currentSpawnPosType)
            currentSpawnPosType = selectedSpawnPosType;

        selectedSpawnPosType = (SpawnPositionTypes)EditorGUILayout.EnumPopup(currentSpawnPosType);
        spawnPositionType.enumValueIndex = (int)selectedSpawnPosType;
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Possible Spawn Points:", EditorStyles.boldLabel);
        using (new EditorGUI.IndentLevelScope())
        {

            if (selectedSpawnPosType == SpawnPositionTypes.Relative)
            {
                ShowSpawnPoints(possibleRelativeToScreenSpawnPoints, "screenPosition", "initialVelocity");
            }
            else
            {
                ShowSpawnPoints(possibleTransformSpawnPoints, "transformSpawnPoint", "initialVelocity");
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void ShowSpawnPoints(SerializedProperty spawnPointListProperty, string spawnPositionPropertyName, string velocityPropertyName)
    {
        for (int i = 0; i < spawnPointListProperty.arraySize; i++)
        {
            SerializedProperty currentElement = spawnPointListProperty.GetArrayElementAtIndex(i);

            EditorGUILayout.LabelField("Spawn Point " + (i + 1));
            using (new EditorGUI.IndentLevelScope())
            {
                if (string.Equals(spawnPositionPropertyName, "screenPosition"))
                {
                    screenPosVector.x = EditorGUILayout.Slider("% of Screen (X axis)", currentElement.FindPropertyRelative(spawnPositionPropertyName).vector2Value.x, 0, 100);
                    screenPosVector.y = EditorGUILayout.Slider("% of Screen (Y axis)", currentElement.FindPropertyRelative(spawnPositionPropertyName).vector2Value.y, 0, 100);
                      
                    currentElement.FindPropertyRelative(spawnPositionPropertyName).vector2Value = screenPosVector;
                }
                else
                    EditorGUILayout.PropertyField(currentElement.FindPropertyRelative(spawnPositionPropertyName));
                EditorGUILayout.PropertyField(currentElement.FindPropertyRelative(velocityPropertyName));
            }
        }

        if (spawnPointListProperty.arraySize == 0)
            EditorGUILayout.LabelField("No spawn points have been created.");

        EditorGUILayout.Space();

        AddOrRemoveSpawnPoint(spawnPointListProperty);
    }
    private void AddOrRemoveSpawnPoint(SerializedProperty spawnPointListProperty)
    {
        GUI.backgroundColor = Color.green;
        addBtnVal = GUILayout.Button("Add new spawn point");
        if (addBtnVal)
        {
            spawnPointListProperty.InsertArrayElementAtIndex(spawnPointListProperty.arraySize);                
            addBtnVal = false;
        }
        GUI.backgroundColor = Color.red;
        removeBtnVal = GUILayout.Button("Remove spawn point");
        if (removeBtnVal && spawnPointListProperty.arraySize >= 1)
        {
            spawnPointListProperty.DeleteArrayElementAtIndex(spawnPointListProperty.arraySize - 1);
            removeBtnVal = false;
        }
    }
}
public enum SpawnPositionTypes
{
    Relative,
    Absolute
}
#endif
