using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KnockbackApplier : MonoBehaviour
{
    private Vector2 currentVelocity;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Knockbackable knockbackable = collision.transform.root.GetComponentInChildren<Knockbackable>();
        if (knockbackable != null)
            knockbackable.ApplyKnockbackOnCollision(gameObject, currentVelocity);          
    }
    private void Update()
    {
        if (_rb2d.velocity != Vector2.zero)
            currentVelocity = _rb2d.velocity;
    }
}
