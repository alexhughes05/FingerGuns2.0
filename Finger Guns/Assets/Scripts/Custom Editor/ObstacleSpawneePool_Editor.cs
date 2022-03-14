using UnityEngine;
using UnityEditor;
using System;

#if UNITY_EDITOR
[CustomEditor(typeof(ObstacleSpawneePool))]
public class ObstacleSpawneePool_Editor : Editor
{
    private SerializedProperty spawnRateInSeconds;
    private SerializedProperty minSpawnRateInSeconds;
    private SerializedProperty maxSpawnRateInSeconds;
    private SerializedProperty spawnRateValueType;
    private SerializedProperty spawnPositionType;
    private SerializedProperty spawnPosValueType;
    private SerializedProperty possibleTransformSpawnPoints;
    private SerializedProperty possibleRelativeToScreenSpawnPoints;
    private bool addBtnVal;
    private bool removeBtnVal;
    private Vector2 screenPosVector = Vector2.zero;
    private SpawnPositionType selectedSpawnPosType;
    private EditorValueType selectedSpawnRateValueType;
    private EditorValueType selectedSpawnPosValueType;

    private float minScaleMultiplier = 0;
    private float maxScaleMultiplier = 0;
    private float minScreenWidth;
    private float maxScreenWidth;
    private float minScreenHeight;
    private float maxScreenHeight;
    private readonly float minScreenSliderLimit = 0;
    private readonly float maxScreenSliderLimit = 100;
    private readonly float minScaleSliderLimit = 0.1f;
    private readonly float maxScaleSliderLimit = 10f;

    void OnEnable()
    {
        spawnRateInSeconds = serializedObject.FindProperty("spawnRateInSeconds");
        minSpawnRateInSeconds = serializedObject.FindProperty("_minSpawnRateInSeconds");
        maxSpawnRateInSeconds = serializedObject.FindProperty("_maxSpawnRateInSeconds");
        spawnRateValueType = serializedObject.FindProperty("spawnRateValueType");
        spawnPositionType = serializedObject.FindProperty("_spawnType");
        possibleTransformSpawnPoints = serializedObject.FindProperty("_possibleTransformSpawnPoints");
        possibleRelativeToScreenSpawnPoints = serializedObject.FindProperty("_possibleRelativeSpawnPoints");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();

        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Spawn Time", EditorStyles.boldLabel, GUILayout.MaxWidth(150));
        selectedSpawnRateValueType = (EditorValueType)EditorGUILayout.EnumPopup((EditorValueType)spawnRateValueType.enumValueIndex);
        EditorGUILayout.EndHorizontal();
        spawnRateValueType.enumValueIndex = (int)selectedSpawnRateValueType;
        using (new EditorGUI.IndentLevelScope())
        {
            if (selectedSpawnRateValueType == EditorValueType.Constant)
            {
                spawnRateInSeconds.floatValue = EditorGUILayout.FloatField("Spawn Time:", Mathf.Max(0, spawnRateInSeconds.floatValue));
            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                minSpawnRateInSeconds.floatValue = EditorGUILayout.FloatField("Min Spawn Time:", Mathf.Max(0, minSpawnRateInSeconds.floatValue));
                maxSpawnRateInSeconds.floatValue = EditorGUILayout.FloatField("Max Spawn Time:", Mathf.Max(0, maxSpawnRateInSeconds.floatValue));
                EditorGUILayout.EndHorizontal();
            }
        }

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Spawn Position Type:", EditorStyles.boldLabel);
        selectedSpawnPosType = (SpawnPositionType)EditorGUILayout.EnumPopup((SpawnPositionType)spawnPositionType.enumValueIndex);
        spawnPositionType.enumValueIndex = (int)selectedSpawnPosType;
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Possible Spawn Points:", EditorStyles.boldLabel);
        using (new EditorGUI.IndentLevelScope())
        {

            if (selectedSpawnPosType == SpawnPositionType.Relative)
            {
                ShowSpawnPoints(possibleRelativeToScreenSpawnPoints, "screenPosition");
            }
            else
            {
                ShowSpawnPoints(possibleTransformSpawnPoints, "transformSpawnPoint");
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void ShowSpawnPoints(SerializedProperty spawnPointListProperty, string spawnPositionPropertyName)
    {
        for (int i = 0; i < spawnPointListProperty.arraySize; i++)
        {
            if (i > 0)
            {
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }

            SerializedProperty currentElement = spawnPointListProperty.GetArrayElementAtIndex(i);
            spawnPosValueType = currentElement.FindPropertyRelative("spawnPointValueType");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Spawn Point " + (i + 1), EditorStyles.boldLabel, GUILayout.MaxWidth(150));
            selectedSpawnPosValueType = (EditorValueType)EditorGUILayout.EnumPopup((EditorValueType)spawnPosValueType.enumValueIndex);
            spawnPosValueType.enumValueIndex = (int)selectedSpawnPosValueType;
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            using (new EditorGUI.IndentLevelScope())
            {
                if (string.Equals(spawnPositionPropertyName, "screenPosition"))
                {
                    var screenPosProperty = currentElement.FindPropertyRelative(spawnPositionPropertyName);

                    if (selectedSpawnPosValueType == EditorValueType.Constant)
                    {
                        var screenWidthPosOffsetProperty = currentElement.FindPropertyRelative("screenWidthPosOffset");
                        var screenHeightPosOffsetProperty = currentElement.FindPropertyRelative("screenHeightPosOffset");

                        screenPosVector.x = EditorGUILayout.Slider("Screen Width %", screenPosProperty.vector2Value.x, 0, 100);
                        screenWidthPosOffsetProperty.floatValue = EditorGUILayout.FloatField("Width Offset", screenWidthPosOffsetProperty.floatValue);

                        EditorGUILayout.Space();

                        screenPosVector.y = EditorGUILayout.Slider("Screen Height %", screenPosProperty.vector2Value.y, 0, 100);
                        screenHeightPosOffsetProperty.floatValue = EditorGUILayout.FloatField("Height Offset", screenHeightPosOffsetProperty.floatValue);

                        screenPosProperty.vector2Value = screenPosVector;
                    }
                    else
                    {
                        var minScreenWidthProperty = currentElement.FindPropertyRelative("minScreenWidth");
                        var maxScreenWidthProperty = currentElement.FindPropertyRelative("maxScreenWidth");
                        var minScreenHeightProperty = currentElement.FindPropertyRelative("minScreenHeight");
                        var maxScreenHeightProperty = currentElement.FindPropertyRelative("maxScreenHeight");
                        var minScreenWidthOffsetProperty = currentElement.FindPropertyRelative("minScreenWidthOffset");
                        var maxScreenWidthOffsetProperty = currentElement.FindPropertyRelative("maxScreenWidthOffset");
                        var minScreenHeightOffsetProperty = currentElement.FindPropertyRelative("minScreenHeightOffset");
                        var maxScreenHeightOffsetProperty = currentElement.FindPropertyRelative("maxScreenHeightOffset");

                        minScreenWidth = minScreenWidthProperty.floatValue;
                        maxScreenWidth = maxScreenWidthProperty.floatValue;
                        minScreenHeight = minScreenHeightProperty.floatValue;
                        maxScreenHeight = maxScreenHeightProperty.floatValue;

                        EditorGUILayout.BeginHorizontal();
                        EditorGUIUtility.labelWidth = 140f;
                        EditorGUILayout.LabelField("Min Screen Width:", string.Format("{0:0.0}", minScreenWidth) + "%");
                        EditorGUILayout.LabelField("Max Screen Width:", string.Format("{0:0.0}", maxScreenWidth) + "%");
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.MinMaxSlider(ref minScreenWidth, ref maxScreenWidth, minScreenSliderLimit, maxScreenSliderLimit);

                        EditorGUILayout.BeginHorizontal();
                        minScreenWidthOffsetProperty.floatValue = EditorGUILayout.FloatField("Left Offset", minScreenWidthOffsetProperty.floatValue);
                        maxScreenWidthOffsetProperty.floatValue = EditorGUILayout.FloatField("Right Offset", maxScreenWidthOffsetProperty.floatValue);
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.Space();
                        EditorGUILayout.Space();

                        EditorGUILayout.BeginHorizontal();
                        EditorGUIUtility.labelWidth = 140f;
                        EditorGUILayout.LabelField("Min Screen Height:", string.Format("{0:0.0}", minScreenHeight) + "%");
                        EditorGUILayout.LabelField("Max Screen Height:", string.Format("{0:0.0}", maxScreenHeight) + "%");
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.MinMaxSlider(ref minScreenHeight, ref maxScreenHeight, minScreenSliderLimit, maxScreenSliderLimit);

                        EditorGUILayout.BeginHorizontal();
                        minScreenHeightOffsetProperty.floatValue = EditorGUILayout.FloatField("Top Offset", minScreenHeightOffsetProperty.floatValue);
                        maxScreenHeightOffsetProperty.floatValue = EditorGUILayout.FloatField("Bottom Offset", maxScreenHeightOffsetProperty.floatValue);
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.Space();

                        minScreenWidthProperty.floatValue = minScreenWidth;
                        maxScreenWidthProperty.floatValue = maxScreenWidth;
                        minScreenHeightProperty.floatValue = minScreenHeight;
                        maxScreenHeightProperty.floatValue = maxScreenHeight;
                    }
                }
                else
                {
                    EditorGUILayout.Space();
                    if (selectedSpawnPosValueType == EditorValueType.Constant)
                        EditorGUILayout.PropertyField(currentElement.FindPropertyRelative(spawnPositionPropertyName), new GUIContent("Transform:"));
                    else
                    {
                        EditorGUILayout.PropertyField(currentElement.FindPropertyRelative("topLeftTransform"), new GUIContent("Top Left:"));
                        EditorGUILayout.PropertyField(currentElement.FindPropertyRelative("bottomRightTransform"), new GUIContent("Bot Right:"));
                    }
                    EditorGUILayout.Space();
                }

                var minScaleMultiplierProperty = currentElement.FindPropertyRelative("minScaleMultiplier");
                var maxScaleMultiplierProperty = currentElement.FindPropertyRelative("maxScaleMultiplier");
                minScaleMultiplier = minScaleMultiplierProperty.floatValue;
                maxScaleMultiplier = maxScaleMultiplierProperty.floatValue;

                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();
                EditorGUIUtility.labelWidth = 140f;
                EditorGUILayout.LabelField("Min Scale Size:", string.Format("{0:0.0}", minScaleMultiplier) + "X");
                EditorGUILayout.LabelField("Max Scale Size:", string.Format("{0:0.0}", maxScaleMultiplier) + "X");
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.MinMaxSlider(ref minScaleMultiplier, ref maxScaleMultiplier, minScaleSliderLimit, maxScaleSliderLimit);

                minScaleMultiplierProperty.floatValue = minScaleMultiplier;
                maxScaleMultiplierProperty.floatValue = maxScaleMultiplier;

                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(currentElement.FindPropertyRelative("initialVelocity"));

                EditorGUILayout.Space();
                EditorGUIUtility.labelWidth = 150.0f;
                EditorGUILayout.PropertyField(currentElement.FindPropertyRelative("zAxisSpawnPoint"), new GUIContent("Z Axis: "), GUILayout.MaxWidth(270));
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
public enum SpawnPositionType
{
    Relative,
    Absolute
}

public enum EditorValueType
{
    Constant,
    RandomBetweenTwoConstants
}
#endif
