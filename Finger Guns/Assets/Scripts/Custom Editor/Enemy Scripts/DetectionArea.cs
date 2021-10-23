using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    //Private fields
    private Patrolling patrollingScript;
    
    //Properties
    public GameObject CurrentTarget { get; private set; }
    private void Awake()
    {
        patrollingScript = GetComponent<Patrolling>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) //If collision is the the player
        {
            patrollingScript.TargetInAggroRange = true;
            CurrentTarget = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
            patrollingScript.TargetInAggroRange = false;
    }
}