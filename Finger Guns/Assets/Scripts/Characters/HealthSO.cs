using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Entity Config/Health")]
public class HealthSO : ScriptableObject
{
    [SerializeField] private int _initialHealth;
    [SerializeField] [ReadOnly] private int _currentHealth;
    [SerializeField] [ReadOnly] private int _maxHealth;

    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    public void InflictDamage(int damage)
    {
        _currentHealth -= damage;
    }

    public void RestoreHealth(int healAmount)
    {
        if (_currentHealth <= MaxHealth)
            _currentHealth += healAmount;
    }
}
