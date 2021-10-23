using UnityEngine;

[CreateAssetMenu(fileName = "New BackflipData", menuName = "Backflip Data")]
public class BackflipData: ScriptableObject
{
    [SerializeField]
    private Vector2 backflipForce;
    [SerializeField]
    private float backflipBufferInSeconds;
    [SerializeField]
    private float coyoteTimeInSeconds;

    public Vector2 BackflipForce { get => backflipForce; }
    public float BackflipBufferInSeconds { get => backflipBufferInSeconds; }
    public float CoyoteTimeInSeconds { get => coyoteTimeInSeconds; }
}
