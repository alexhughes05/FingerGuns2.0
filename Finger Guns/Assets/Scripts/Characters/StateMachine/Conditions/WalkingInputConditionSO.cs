using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "WalkingInputCondition", menuName = "State Machines/Conditions/Walking Input Condition")]
public class WalkingInputConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new WalkingInputCondition();
}

public class WalkingInputCondition : Condition
{
	private FgmInputHandler _fingerGunMan;
	protected new WalkingInputConditionSO OriginSO => (WalkingInputConditionSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}
	
	protected override bool Statement()
	{
		return _fingerGunMan.MovingInput;
	}
	
	public override void OnStateEnter() { }
	
	public override void OnStateExit() { }
}


