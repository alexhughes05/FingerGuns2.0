using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(SpinObject))]
public class SpinObject_Editor : Editor
{
    private SerializedProperty spinInDirectionOfMovement;
    private SerializedProperty rotationDirection;
    private RotationDirection selectedRotationDirection;
    private RotationDirection currentRotationDirection;

    void OnEnable()
    {
        spinInDirectionOfMovement = serializedObject.FindProperty("spinInDirectionOfMovement");
        rotationDirection = serializedObject.FindProperty("rotationDirection");
        currentRotationDirection = (RotationDirection)rotationDirection.enumValueIndex;
        selectedRotationDirection = currentRotationDirection;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        spinInDirectionOfMovement.boolValue = EditorGUILayout.Toggle("Spin In Direction of Movement", spinInDirectionOfMovement.boolValue);
        if (spinInDirectionOfMovement.boolValue == false)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Rotation Direction:", EditorStyles.boldLabel);
            if (selectedRotationDirection != currentRotationDirection)
                currentRotationDirection = selectedRotationDirection;

            selectedRotationDirection = (RotationDirection)EditorGUILayout.EnumPopup(currentRotationDirection);
            rotationDirection.enumValueIndex = (int)selectedRotationDirection;
            EditorGUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
public enum RotationDirection
{
    Clockwise,
    CounterClockwise
}
#endif