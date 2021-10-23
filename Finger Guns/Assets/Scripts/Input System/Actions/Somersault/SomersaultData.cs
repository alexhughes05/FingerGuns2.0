using UnityEngine;

[CreateAssetMenu(fileName = "New SomersaultData", menuName = "Somersault Data")]
public class SomersaultData: ScriptableObject
{
    [SerializeField]
    private Vector2 somersaultForce;
    [SerializeField]
    private float somersaultBufferInSeconds;
    [SerializeField]
    private float coyoteTimeInSeconds;

    public Vector2 SomersaultForce { get => somersaultForce; }
    public float SomersaultBufferInSeconds { get => somersaultBufferInSeconds; }
    public float CoyoteTimeInSeconds { get => coyoteTimeInSeconds; }
}
