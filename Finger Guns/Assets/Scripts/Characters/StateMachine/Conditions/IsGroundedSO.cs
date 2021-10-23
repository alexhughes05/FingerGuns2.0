using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsGrounded", menuName = "State Machines/Conditions/Is Grounded")]
public class IsGroundedSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsGrounded();
}

public class IsGrounded : Condition
{
	private GroundedChecker _groundedChecker;

	public override void Awake(StateMachine stateMachine)
	{
		_groundedChecker = stateMachine.GetComponent<GroundedChecker>();
	}
	
	protected override bool Statement()
	{
		return _groundedChecker.Grounded;
	}
	
	public override void OnStateEnter() { }
	
	public override void OnStateExit() {}
}
