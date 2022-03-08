using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    //Components
    private Damageable playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Damageable>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            //playerHealth.TakeDamage((int)playerHealth.CurrentHealth);
            //Play audible scream here
        }
    }
}
