using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Squisher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Squishable squishable = collision.transform.root.GetComponentInChildren<Squishable>();
        if (squishable != null)
            squishable.ApplySquishOnCollision();
    }
}
