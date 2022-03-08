using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsStandUpAnimDone", menuName = "State Machines/Conditions/Is Stand Up Anim Done")]
public class IsStandUpAnimDoneSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsStandUpAnimDone();
}

public class IsStandUpAnimDone : Condition
{
	private FgmInputHandler _fingerGunMan;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}

	protected override bool Statement()
	{
		return _fingerGunMan.IsStandUpAnimDone();
	}

	public override void OnStateEnter()
	{
		_fingerGunMan.SetEndOfStandUpAnim(0);
	}

	public override void OnStateExit()
	{
		_fingerGunMan.SetEndOfStandUpAnim(0);
	}
}
