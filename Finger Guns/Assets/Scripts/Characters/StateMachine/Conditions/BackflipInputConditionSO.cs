using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "BackflipInputCondition", menuName = "State Machines/Conditions/Backflip Input Condition")]
public class BackflipInputConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new BackflipInputCondition();
}

public class BackflipInputCondition : Condition
{
	private FgmInputHandler _fingerGunMan;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}

	protected override bool Statement()
	{
		return _fingerGunMan.BackflipInput;
	}

	public override void OnStateEnter() { }

	public override void OnStateExit() { }
}
