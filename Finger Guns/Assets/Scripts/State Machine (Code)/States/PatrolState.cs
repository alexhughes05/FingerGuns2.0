using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    private readonly Patrolling enemy;

    public PatrolState(Patrolling enemy)
    {
        this.enemy = enemy;
    }

    public void Tick()
    {
    }
    public void OnEnter(){}

    public void OnExit(){}
}
