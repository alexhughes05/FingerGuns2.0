using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Squishable : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Damageable _damageable;

    public bool ShouldSquish { get; set; }

    void Awake()
    {
        TryGetComponent(out _damageable);

        TryGetComponent(out _rb2d);
        if (_rb2d == null)
            Debug.LogError("Squishable was unable to find the Rigidbody2D component on gameobject " + gameObject.name);
    }

    public void ApplySquishOnCollision()
    {
        if (_damageable && !_damageable.Invulnerable)
            ShouldSquish = true;
    }
}
