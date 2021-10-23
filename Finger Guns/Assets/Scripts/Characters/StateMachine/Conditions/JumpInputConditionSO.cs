using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "JumpInputCondition", menuName = "State Machines/Conditions/Jump Input Condition")]
public class JumpInputConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new JumpInputCondition();
}

public class JumpInputCondition : Condition
{
	private FgmInputHandler _fingerGunMan;
	protected new JumpInputConditionSO OriginSO => (JumpInputConditionSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}
	
	protected override bool Statement()
	{
		return _fingerGunMan.JumpInput;
	}
	
	public override void OnStateEnter() 
	{
		_fingerGunMan.SetEndOfJumpCriticalSection(0);
	}

	
	public override void OnStateExit() { }
}
