using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "CrouchInputCondition", menuName = "State Machines/Conditions/Crouch Input Condition")]
public class CrouchInputConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new CrouchInputCondition();
}

public class CrouchInputCondition : Condition
{
	private FgmInputHandler _fingerGunMan;
	protected new CrouchInputConditionSO OriginSO => (CrouchInputConditionSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}
	
	protected override bool Statement()
	{
		return _fingerGunMan.CrouchInput;
	}
	
	public override void OnStateEnter() { }
	
	public override void OnStateExit() { }
}
