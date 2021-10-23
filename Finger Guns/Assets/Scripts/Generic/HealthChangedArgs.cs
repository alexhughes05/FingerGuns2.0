using System;

public class HealthChangedArgs : EventArgs
{
    public float CurrentHealth { get; }
    public float MaxHealth { get; }

    public HealthChangedArgs(float currentHealth, float maxHealth)
    {
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
    }
}
