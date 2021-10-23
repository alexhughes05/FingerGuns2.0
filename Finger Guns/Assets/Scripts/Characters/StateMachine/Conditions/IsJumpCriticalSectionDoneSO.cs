using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsJumpCriticalSectionDone", menuName = "State Machines/Conditions/Is Jump Critical Section Done")]
public class IsJumpCriticalSectionDoneSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsJumpAnimFinished();
}

public class IsJumpAnimFinished : Condition
{
	private FgmInputHandler _fingerGunMan;
	protected new IsJumpCriticalSectionDoneSO OriginSO => (IsJumpCriticalSectionDoneSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}
	
	protected override bool Statement()
	{
		return _fingerGunMan.IsJumpCriticalSectionDone();
	}	
	public override void OnStateEnter() 
	{
		_fingerGunMan.SetEndOfJumpCriticalSection(0);
	}
	
	public override void OnStateExit() 
	{
		_fingerGunMan.SetEndOfJumpCriticalSection(0);
	}
}
