using System;
using UnityEngine;

public class FgmStateController : MonoBehaviour
{
    //Private Fields
    private FgmIdleState fgmIdleState;
    private FgmWalkingState fgmWalkingState;
    private FgmJumpState fgmJumpState;
    private FgmCrouchState fgmCrouchState;
    private FgmSlidingState fgmSlidingState;
    private FgmSomersaultState fgmSomersaultState;
    private FgmBackflipState fgmBackflipState;
    private FgmFallingState fgmFallingState;
    private FgmLandingState fgmLandingState;
    private FgmAfkState fgmAfkState;
    private FgmKnockedDownState fgmKnockedDownState;
    private FgmStandUpState fgmStandUpState;
    
    //Properties
    public StateMachineWithCode fgmStateMachineBaseLayer { get; private set; }
    private void Awake()
    {
        fgmStateMachineBaseLayer = new StateMachineWithCode();

        //Define States
        InitializeStates();

        //Define Transitions
        DefineTransitions();

        //Set starting state
        fgmStateMachineBaseLayer.SetState(fgmIdleState);
    }

    private void Update() => fgmStateMachineBaseLayer.Tick();

    private void InitializeStates()
    {
        fgmIdleState = new FgmIdleState(GetComponent<Rigidbody2D>());
        //fgmWalkingState = new FgmWalkingState(this);
        //fgmJumpState = new FgmJumpState(this);
        //fgmCrouchState = new FgmCrouchState(this);
        //fgmSlidingState = new FgmSlidingState(this);
        //fgmSomersaultState = new FgmSomersaultState(this);
        //fgmBackflipState = new FgmBackflipState(this);
        //fgmFallingState = new FgmFallingState(this);
        //fgmLandingState = new FgmLandingState(this);
        //fgmAfkState = new FgmAfkState(this);
        //fgmKnockedDownState = new FgmKnockedDownState(this);
        //fgmStandingUpState = new FgmStandingUpState(this);

        //Falling_Walking
        //Crouching_Walking
    }
    private void DefineTransitions()
    {

    }
}
