using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsSomersaultAnimDone", menuName = "State Machines/Conditions/Is Somersault Anim Done")]
public class IsSomersaultAnimDoneSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsSomersaultAnimDone();
}

public class IsSomersaultAnimDone : Condition
{
	private FgmInputHandler _fingerGunMan;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}

	protected override bool Statement()
	{
		return _fingerGunMan.IsSomersaultAnimDone();
	}
	public override void OnStateEnter() 
	{
		_fingerGunMan.SetEndOfSomersaultAnim(0);
	}

	public override void OnStateExit() 
	{
		_fingerGunMan.SetEndOfSomersaultAnim(0);
	}
}
