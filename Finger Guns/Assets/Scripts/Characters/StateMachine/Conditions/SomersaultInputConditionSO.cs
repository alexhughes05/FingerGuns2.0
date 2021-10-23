using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "SomersaultInputCondition", menuName = "State Machines/Conditions/Somersault Input Condition")]
public class SomersaultInputConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new SomersaultInputCondition();
}

public class SomersaultInputCondition : Condition
{
	private FgmInputHandler _fingerGunMan;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}

	protected override bool Statement()
	{
		return _fingerGunMan.SomersaultInput;
	}

	public override void OnStateEnter() { }

	public override void OnStateExit() { }
}
