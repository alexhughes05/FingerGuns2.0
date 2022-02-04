using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsLandingCriticalSectionDone", menuName = "State Machines/Conditions/Is Landing Critical Seection Done")]
public class IsLandingCriticalSectionDoneSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsLandingAnimFinished();
}

public class IsLandingAnimFinished : Condition
{
	private FgmInputHandler _fingerGunMan;
	protected new IsLandingCriticalSectionDoneSO OriginSO => (IsLandingCriticalSectionDoneSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_fingerGunMan = stateMachine.GetComponent<FgmInputHandler>();
	}
	
	protected override bool Statement()
	{
		return _fingerGunMan.IsLandingAnimDone();
	}
	
	public override void OnStateEnter() 
	{
		_fingerGunMan.SetEndOfLandingAnim(0);
	}

	public override void OnStateExit() 
	{
		_fingerGunMan.SetEndOfLandingAnim(0);
	}

}
