using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    //Inspector
    [SerializeField]
    private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            Projectile projectile = gameObject.GetComponent<Projectile>();
            if (projectile) projectile.AssociatedShotPool.ReturnToPool(projectile);
        }
    }
}

