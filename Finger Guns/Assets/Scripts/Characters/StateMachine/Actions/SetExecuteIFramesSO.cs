using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "SetExecuteIFrames", menuName = "State Machines/Actions/Set Execute IFrames")]
public class SetExecuteIFramesSO : StateActionSO
{
	[Space]
	[SerializeField] private Moment whenToRun;
	[SerializeField] private bool desiredValue;
	protected override StateAction CreateAction() => new SetExecuteIFrames(whenToRun, desiredValue);
}

public class SetExecuteIFrames : StateAction
{
	private readonly Moment _whenToRun;
	private readonly bool _desiredValue;

	private MaterialModifier _materialModifier;
	public SetExecuteIFrames(Moment whenToRun, bool desiredValue)
    {
		_whenToRun = whenToRun;
		_desiredValue = desiredValue;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _materialModifier);
		if (_materialModifier == null)
			Debug.LogError("SetExecuteIFrames was unable to find the MaterialModifier component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
		UpdateExecuteIFrames(Moment.OnUpdate);
	}
	
	public override void OnStateEnter()
	{
		UpdateExecuteIFrames(Moment.OnStateEnter);
	}
	
	public override void OnStateExit()
	{
		UpdateExecuteIFrames(Moment.OnStateExit);
	}

	private void UpdateExecuteIFrames(Moment specifiedMoment)
    {
		if (specifiedMoment == _whenToRun)
			_materialModifier.ExecuteIFrames = _desiredValue;
    }
}
