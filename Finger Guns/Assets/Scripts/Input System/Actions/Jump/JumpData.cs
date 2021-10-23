using UnityEngine;

[CreateAssetMenu(fileName = "New JumpData", menuName = "Jump Data")]
public class JumpData : ScriptableObject
{
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float jumpBufferInSeconds;

    public float JumpForce { get => jumpForce; }
    public float JumpBufferInSeeconds { get => jumpBufferInSeconds; }

}
