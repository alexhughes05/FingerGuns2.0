using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "TrueCondition", menuName = "State Machines/Conditions/True Condition")]
public class TrueConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new TrueCondition();
}

public class TrueCondition : Condition
{
	protected new TrueConditionSO OriginSO => (TrueConditionSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	protected override bool Statement()
	{
		return true;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
