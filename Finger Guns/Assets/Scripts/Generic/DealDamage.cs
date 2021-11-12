using UnityEngine;

public class DealDamage : MonoBehaviour
{
    //Inspector
    [SerializeField]
    private int damage;

    private bool tookDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var root = collision.gameObject.transform.root;
        IDamageable damageable = root.GetComponentInChildren<IDamageable>();

        if (damageable != null && tookDamage == false)
        {
            tookDamage = true;
            damageable.TakeDamage(damage);

            IPoolable poolable = gameObject.GetComponent<IPoolable>();
            if (poolable != null & poolable.AssociatedPool != null) poolable.AssociatedPool.ReturnToPool(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var root = collision.gameObject.transform.root;
        IDamageable damageable = root.GetComponentInChildren<IDamageable>();

        if (damageable != null && tookDamage == false)
        {
            tookDamage = true;
            damageable.TakeDamage(damage);

            IPoolable poolable = gameObject.GetComponent<IPoolable>();
            if (poolable != null & poolable.AssociatedPool != null) poolable.AssociatedPool.ReturnToPool(gameObject);
        }
    }  

    private void LateUpdate()
    {
        tookDamage = false;
    }
}

