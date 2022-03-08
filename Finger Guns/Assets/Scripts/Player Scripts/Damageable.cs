using UnityEngine;

public class Damageable : MonoBehaviour
{
    #region Variables

    //Inspector
    [SerializeField] private HealthConfigSO _healthConfigSO;
    [SerializeField] private HealthSO _currentHealthSO;
    [Header("Broadcasting On")]
    [SerializeField] private VoidEventChannelSO _updateHealthUI = default;
    [SerializeField] private VoidEventChannelSO _deathEvent = default;

    //Private Fields


    //Properties
    public bool TookDamage { get; set; }
    public bool Invulnerable { get; set; }
    public bool IsDead { get; private set; }

    #endregion

    protected void Awake()
    {
        if (_currentHealthSO == null)
        {
            _currentHealthSO = ScriptableObject.CreateInstance<HealthSO>();
            _currentHealthSO.CurrentHealth = _healthConfigSO.InitialHealth;
            _currentHealthSO.MaxHealth = _healthConfigSO.InitialHealth;
        }

        if (_updateHealthUI != null)
            _updateHealthUI.RaiseEvent();
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        if (Invulnerable == false)
        {
            _currentHealthSO.InflictDamage(damage);
            TookDamage = true;

            if (_updateHealthUI != null)
                _updateHealthUI.RaiseEvent();

            if (_currentHealthSO.CurrentHealth <= 0)
                Die();
        }
    }

    private void Die()
    {
        _deathEvent.RaiseEvent();
        IsDead = true;
    }
}



