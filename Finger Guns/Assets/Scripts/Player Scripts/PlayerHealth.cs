using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    #region Variables
    
    //Inspector
    [SerializeField] int maxHealth;
    [SerializeField] private GameEvent playerDeathEventSO;

    //Events
    public event EventHandler<HealthChangedArgs> HealthChanged = delegate { };

    //Properties
    public bool PlayerDead { get; set; } 
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    
    #endregion

    #region Monobehaviour Callbacks

    private void Awake()
    {
        CurrentHealth = maxHealth;
        MaxHealth = maxHealth;
    }

    #endregion

    #region Implemented Methods
    public void TakeDamage(int damage)
    {
        if (PlayerDead) return;
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
        HealthChanged(this, new HealthChangedArgs(CurrentHealth, MaxHealth));
        if (CurrentHealth == 0)
        {
            PlayerDead = true;
            playerDeathEventSO.Raise();
        }
    }

    #endregion
}