using UnityEngine;

public class DealDamage : MonoBehaviour
{
    //Inspector
    [SerializeField]
    private int damage;

    //Private Fields
    private bool alreadyDamaged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alreadyDamaged == false) //Avoids bug where entity takes damage twice in the same frame.
        {
            var root = collision.gameObject.transform.root;
            Damageable damageable = root.GetComponentInChildren<Damageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                alreadyDamaged = true;

                IPoolable poolable = gameObject.GetComponent<IPoolable>();
                if (poolable != null && poolable.AssociatedPool != null)
                    poolable.AssociatedPool.ReturnToPool(gameObject);
            }
        }
    }

    private void LateUpdate()
    {
        alreadyDamaged = false;
    }
}

