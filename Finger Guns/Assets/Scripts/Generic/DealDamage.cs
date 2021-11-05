using UnityEngine;

public class DealDamage : MonoBehaviour
{
    //Inspector
    [SerializeField]
    private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var root = collision.gameObject.transform.root;
        IDamageable damageable = root.GetComponentInChildren<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);

            IPoolable poolable = gameObject.GetComponent<IPoolable>();
            if (poolable != null) poolable.AssociatedPool.ReturnToPool(gameObject);
        }
    }
}

