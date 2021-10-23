using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsBackflipAnimDone", menuName = "State Machines/Conditions/Is Backflip Anim Done")]
public class IsBackflipAnimDoneSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsBackflipAnimDone();
}

public class IsBackflipAnimDone : Condition
{
	private FgmInputHandler _fingerGunMan;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}

	protected override bool Statement()
	{
		return _fingerGunMan.IsBackflipAnimDone();
	}
	public override void OnStateEnter() 
	{
		_fingerGunMan.SetEndOfBackflipAnim(0);
	}

	public override void OnStateExit() 
	{
		_fingerGunMan.SetEndOfBackflipAnim(0);
	}
}
