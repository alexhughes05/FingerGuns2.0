using UnityEngine;
using UnityEngine.UI;

public class HeartDisplayer : MonoBehaviour
{
    //Inspector
    [SerializeField] private HealthConfigSO _healthConfigSO = default;
    [SerializeField] private HealthSO _currentHealthSO = default; //the Health display is watching this object
    [Header("Listening to")]
    [SerializeField] private VoidEventChannelSO _UIUpdateNeeded = default; //The player's Damageable issues this
    [Header("UI")]
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField]private Image[] hearts;

    private void OnEnable()
    {
        _UIUpdateNeeded.OnEventRaised += UpdateHeartImages;

        InitializeHealthBar();
    }

    private void OnDestroy()
    {
        _UIUpdateNeeded.OnEventRaised -= UpdateHeartImages;
    }

    private void InitializeHealthBar()
    {
        _currentHealthSO.MaxHealth = _healthConfigSO.InitialHealth;
        _currentHealthSO.CurrentHealth = _healthConfigSO.InitialHealth;

        UpdateHeartImages();
    }

    public void UpdateHeartImages()
    {
        //Set up player health display
        if (fullHeart != null)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < _currentHealthSO.CurrentHealth)
                    hearts[i].sprite = fullHeart;
                else
                    hearts[i].sprite = emptyHeart;

                if (i < _currentHealthSO.MaxHealth)
                    hearts[i].enabled = true;
                else
                    hearts[i].enabled = false;
            }
        }
    }
}
