using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "SetStandUp", menuName = "State Machines/Actions/Set Stand Up")]
public class SetStandUpSO : StateActionSO
{
	[SerializeField] private StandUpType standUpType;
	[SerializeField] private Moment whenToRun;
	[SerializeField] private bool desiredValue;
	protected override StateAction CreateAction() => new SetStandUp(standUpType, whenToRun, desiredValue);
}

public class SetStandUp : StateAction
{
	private readonly Moment _whenToRun;
	private readonly bool _desiredValue;
	private readonly StandUpType _standUpType;

	private Knockbackable _knockbackable;
	public SetStandUp(StandUpType standUpType, Moment whenToRun, bool desiredValue)
    {
		_standUpType = standUpType;
		_whenToRun = whenToRun;
		_desiredValue = desiredValue;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _knockbackable);
		if (_knockbackable == null)
			Debug.LogError("SetStandUp was unable to find the Knockbackable component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
		ModifyStandUpBool(Moment.OnUpdate);
	}
	
	public override void OnStateEnter()
	{
		ModifyStandUpBool(Moment.OnStateEnter);
	}
	
	public override void OnStateExit()
	{
		ModifyStandUpBool(Moment.OnStateExit);
	}

	private void ModifyStandUpBool(Moment specifiedMoment)
    {
		if (specifiedMoment == _whenToRun)
        {
			if (_standUpType == StandUpType.Normal)
				_knockbackable.StandUp = _desiredValue;
			else
				_knockbackable.StandUpForward = _desiredValue;
		}
    }
}
