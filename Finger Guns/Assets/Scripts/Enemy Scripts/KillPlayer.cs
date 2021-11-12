using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    //Components
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            playerHealth.TakeDamage((int)playerHealth.CurrentHealth);
            //Play audible scream here
        }
    }
}
