using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    //Private Fields
    private GameObject currentTarget;

    //References
    private readonly IAttack attacker;
    private readonly DetectionArea detectionArea;

    public AttackState(Patrolling enemy)
    {
        detectionArea = enemy.GetComponent<DetectionArea>();
        attacker = enemy.GetComponent<IAttack>();
    }

    public void Tick()
    {
        Debug.Log("in attack state.");
        currentTarget = detectionArea.CurrentTarget;
        if (currentTarget != null)
            attacker?.Attack(currentTarget.transform.position);
    }

    public void OnEnter(){}

    public void OnExit(){}
}
