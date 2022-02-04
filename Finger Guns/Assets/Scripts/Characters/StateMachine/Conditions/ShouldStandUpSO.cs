using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ShouldStandUp", menuName = "State Machines/Conditions/Should Stand Up")]
public class ShouldStandUpSO : StateConditionSO
{
	[SerializeField] private StandUpType standUpType;
	protected override Condition CreateCondition() => new ShouldStandUp(standUpType);
}

public class ShouldStandUp : Condition
{
	private Knockbackable _knockbackable;
	private StandUpType _standUpType;

	public ShouldStandUp(StandUpType standUpType)
    {
		_standUpType = standUpType;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _knockbackable);
		if (_knockbackable == null)
			Debug.LogError("ShouldStandUpSO was unable to find the Knockbackable component on gameobject " + stateMachine.gameObject.name);
	}
	
	protected override bool Statement()
	{
		if (_standUpType == StandUpType.Normal)
			return _knockbackable.StandUp;
		else
			return _knockbackable.StandUpForward;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
