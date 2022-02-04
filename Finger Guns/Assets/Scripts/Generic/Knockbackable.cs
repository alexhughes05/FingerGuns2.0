using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Knockbackable : MonoBehaviour
{
    [SerializeField]
    private float minKnockbackForce;

    private Rigidbody2D _rb2d;
    private Damageable _damageable;
    public bool LeftKnockback { get; set; }
    public bool RightKnockback { get; set; }
    public bool StandUp { get; set; }
    public bool StandUpForward { get; set; }
    public bool NoHorizontalKnockback { get; private set; }
    public Vector2 KnockbackVector { get; set; }
    private void Awake()
    {
        TryGetComponent(out _damageable);

        TryGetComponent(out _rb2d);
        if (_rb2d == null)
            Debug.LogError("Knockbackable was unable to find the Rigidbody2D component on gameobject " + gameObject.name);
    }
    public void ApplyKnockbackOnCollision(GameObject go, Vector2 velocity)
    {
        if (_damageable && !_damageable.Invulnerable)
        {
            // Calculate Angle Between the collision gameObject and the player and normalize it
            var dir = (_rb2d.transform.position - go.transform.position).normalized;

            // Calculate the Knockback force based on the speed of the player and the blade 
            var knockBackForce = CalculateKnockbackForce(velocity);
            KnockbackVector = (dir * knockBackForce);

            if (dir.x > 0)
                RightKnockback = true;
            if (dir.x < 0)
                LeftKnockback = true;
            else
                NoHorizontalKnockback = true;
        }
    }
    private float CalculateKnockbackForce(Vector2 velocity)
    {
        var potentialForce = velocity.magnitude * 3;
        if (potentialForce > 70)
            potentialForce = 70;
        return (potentialForce > minKnockbackForce) ? potentialForce : minKnockbackForce;
    }
}
