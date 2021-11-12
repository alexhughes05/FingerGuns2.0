using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KnockbackApplier : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    private bool knockBackTriggered;
    private Vector3 currentVelocity;
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent(out IKnockbackable knockbackable);
        if (knockbackable != null && knockBackTriggered == false)
        {
            collision.gameObject.TryGetComponent(out MoveBehaviour moveBehaviour);
            if (moveBehaviour != null)
            {
                moveBehaviour.MovementInputDisabled = true;
                _rb2d.velocity = Vector2.zero;
                knockBackTriggered = true;
                knockbackable.HandleKnockback(currentVelocity);
            }
        }
    }

    private void LateUpdate()
    {
        currentVelocity = _rb2d.velocity;
        knockBackTriggered = false;
    }
}
