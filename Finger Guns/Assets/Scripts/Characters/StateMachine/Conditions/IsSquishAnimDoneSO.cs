using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsSquishAnimDone", menuName = "State Machines/Conditions/Is Squish Anim Done")]
public class IsSquishAnimDoneSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsSquishAnimDone();
}

public class IsSquishAnimDone : Condition
{
	private FgmInputHandler _fgmInputHandler;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _fgmInputHandler);
		if (_fgmInputHandler == null)
			Debug.LogError("IsSquishAnimDoneSO was unable to find the FgmInputHandler component on gameobject " + stateMachine.gameObject.name);
	}
	
	protected override bool Statement()
	{
		return _fgmInputHandler.IsSquishAnimDone();
	}
	
	public override void OnStateEnter()
	{
		_fgmInputHandler.SetEndOfSquishAnim(0);
	}
	
	public override void OnStateExit()
	{
		_fgmInputHandler.SetEndOfSquishAnim(0);
	}
}
