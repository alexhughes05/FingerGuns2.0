using System;
using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    #region Variables

    //Inspector
    [SerializeField] int maxHealth;
    [SerializeField] private GameEvent playerDeathEventSO;

    //Components and references
    private Animator _anim;

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
        _anim = GetComponent<Animator>();
    }

    #endregion

    #region Implemented Methods
    public void TakeDamage(int damage)
    {
        if (PlayerDead) return;
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
        HealthChanged(this, new HealthChangedArgs(CurrentHealth, MaxHealth));
        if (CurrentHealth == 0)
            Die();
    }
    private void Die()
    {
        _anim.SetTrigger(FGMAnimHashes.PlayerDeathHash);
        playerDeathEventSO.Raise();
        PlayerDead = true;
    }

    #endregion
}
