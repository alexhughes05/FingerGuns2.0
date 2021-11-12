using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    #region Variables

    //Inspector
    [SerializeField] 
    int maxHealth;
    [SerializeField] 
    private GameEvent deathEventSO;

    //Private fields
    private bool isDead;

    //Events
    public event EventHandler<HealthChangedArgs> HealthChanged = delegate { };

    //Properties
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

    #region Interface Implementation 

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
        HealthChanged(this, new HealthChangedArgs(CurrentHealth, MaxHealth));
        if (CurrentHealth == 0)
        {
            isDead = true;
            deathEventSO.Raise();
        }
    }

    #endregion
}
