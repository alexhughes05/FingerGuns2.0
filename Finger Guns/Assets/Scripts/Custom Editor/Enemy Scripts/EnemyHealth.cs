using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    #region Variables

    //Inspector
    [Header("Enemy")]
    [SerializeField] 
    private int maxHealth;
    private int enemyPointValue = 100;

    //Components
    //private GameSession gameSession;
    private Animator anim;

    //Private    
    private bool isDead = false;

    //Properties
    public int CurrentHealth { get; private set; }

    #endregion

    #region Monobehaviour Callbacks

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        //gameSession = FindObjectOfType<GameSession>();
    }

    private void Start() => CurrentHealth = maxHealth;

    #endregion

    #region Implemented Methods
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log("inside currentHealth is " + CurrentHealth);
        if (CurrentHealth <= 0)
        {
            anim.SetTrigger("Death");
            if (gameObject.name.Contains("ExplodeyOne"))
            {
                Destroy(gameObject, 1);
            }
            else
                Destroy(gameObject, 0.5f);
            //AddPoints();
            isDead = true;
        }
        else
            anim.SetTrigger("Take Damage");
    }

    //public void AddPoints()
    //{
    //    if(!isDead)
    //        gameSession.AddToScore(enemyPointValue);
    //}


    #endregion
}