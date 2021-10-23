using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beegman : MonoBehaviour
{
    //public
    [SerializeField] float chargeSpeed;
    [SerializeField] float chargeDistancePastPlayer;
    [SerializeField] float minTimeBtwCharge;
    [SerializeField] float maxTimeBtwCharge;

    //Components
    private FgmInputHandler playerScript;
    private AIPatrol patrolScript;
    private Animator anim;

    //private
    private bool chargePsFlipped;
    private bool chargePsPlayed;
    private ParticleSystem chargePs;
    private bool playerOnRightOfEnemy;
    private bool playerHit;
    private Vector2 targetPos;
    private float playerXPos;
    private float distanceBeyondPlayer = 5;
    private bool inCharge;
    private bool needNewChargeTime = true;

    void Awake()
    {
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        foreach(var particle in particles)
        {
            if (particle.name.ToLower().Contains("charge"))
                chargePs = particle;
        }
        anim = GetComponent<Animator>();
        patrolScript = GetComponent<AIPatrol>();
        playerScript = FindObjectOfType<FgmInputHandler>();
    }

    void Update()
    {
        if (playerScript)
        {
            playerXPos = playerScript.gameObject.transform.position.x;
            targetPos = new Vector2(playerXPos + distanceBeyondPlayer, transform.position.y);
            if (inCharge)
            {
                if (NeedToFlipChargePs && !chargePsFlipped || !NeedToFlipChargePs && chargePsFlipped)
                {
                    chargePsFlipped = !chargePsFlipped;
                    chargePs.transform.localScale = new Vector2(-chargePs.transform.localScale.x, chargePs.transform.localScale.y);
                }

                if (!chargePsPlayed)
                {
                    chargePsPlayed = true;
                    chargePs.Play();
                }
                var movementThisFrame = chargeSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);
                anim.SetFloat("Movement", chargeSpeed);
                if (Vector2.Distance(transform.position, targetPos) <= 0.1 || playerHit)
                {
                    chargePsPlayed = false;
                    chargePs.Stop();
                    anim.SetBool("Charge", false);
                    anim.SetFloat("Movement", 0);
                    needNewChargeTime = true;
                    inCharge = false;
                    playerHit = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10 && inCharge) //hits player
            playerHit = true;
    }

    public IEnumerator HeadButtCharge()
    {
        StartAttackingPlayer = true;
        while (true)
        {
            anim.SetFloat("Movement", 0);
            yield return new WaitUntil(() => !inCharge);
            yield return WaitForNextCharge();
        }
    }

    private IEnumerator WaitForNextCharge()
    {
        ChargeEnteredTime = Time.time;
        if (needNewChargeTime)
        {
            needNewChargeTime = false;
            ChargeRemainingTime = Random.Range(minTimeBtwCharge, maxTimeBtwCharge);
            ChargeStartTime = Time.time;
        }

        yield return new WaitForSeconds(ChargeRemainingTime);
        anim.SetBool("Charge", true);
        playerOnRightOfEnemy = patrolScript.PlayerOnRightOfEnemy();
        
        if (playerOnRightOfEnemy)
            distanceBeyondPlayer = chargeDistancePastPlayer;
        else
            distanceBeyondPlayer = -chargeDistancePastPlayer;

        inCharge = true;
    }

    //Properties
    public bool StartAttackingPlayer { get; set; }
    public bool NeedToFlipChargePs { get; set; }
    public float ChargeRemainingTime { get; set; }
    public float ChargeEnteredTime { get; set; }
    public float ChargeStartTime { get; set; }
}
