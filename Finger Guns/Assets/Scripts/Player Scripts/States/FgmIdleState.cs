using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FgmIdleState : IState
{
    private Rigidbody2D _fgmRb2d;
    public FgmIdleState(Rigidbody2D fgmRb2d)
    {
        _fgmRb2d = fgmRb2d;
    }

    public void OnEnter() 
    {

    }

    public void OnExit() { }

    public void Tick()
    {
        Debug.Log("CurrentState is idle state");
    }
}
