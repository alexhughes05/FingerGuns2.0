using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //Inspector
    [Header("UI")]
    [SerializeField] 
    private Sprite fullHeart;
    [SerializeField] 
    private Sprite emptyHeart;
    [SerializeField]
    private Image[] hearts;

    //Components and References
    private Health playerHealth;

    private void Awake() => playerHealth = FindObjectOfType<Health>();

    private void Start() //Want to change later.
    {
        UpdateHealthUI(playerHealth.CurrentHealth, playerHealth.MaxHealth);
        playerHealth.HealthChanged += HandleHealthChange;
    }

    private void OnDisable() => playerHealth.HealthChanged -= HandleHealthChange;

    private void HandleHealthChange(object sender, HealthChangedArgs e) => UpdateHealthUI(e.CurrentHealth, e.MaxHealth);

    public void UpdateHealthUI(float currentHealth, float maxHealth)
    {
        //Set up player health display
        if (fullHeart != null)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < currentHealth)
                    hearts[i].sprite = fullHeart;
                else
                    hearts[i].sprite = emptyHeart;

                if (i < maxHealth)
                    hearts[i].enabled = true;
                else
                    hearts[i].enabled = false;
            }
        }
    }
}
