using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ApplyFrictionWhenGrounded", menuName = "State Machines/Actions/Apply Friction When Grounded")]
public class ApplyFrictionWhenGroundedSO : StateActionSO
{
	protected override StateAction CreateAction() => new ApplyFrictionWhenGrounded();
}

public class ApplyFrictionWhenGrounded : StateAction
{
	protected new ApplyFrictionWhenGroundedSO OriginSO => (ApplyFrictionWhenGroundedSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
