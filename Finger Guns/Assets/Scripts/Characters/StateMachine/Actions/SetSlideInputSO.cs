using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "SetSlideInput", menuName = "State Machines/Actions/Set Slide Input")]
public class SetSlideInputSO : StateActionSO
{
	[Space]
	[SerializeField]
	private Moment whenToRun;
	[Space]
	[SerializeField]
	private bool desiredValue;
	protected override StateAction CreateAction() => new SetSlideInput(whenToRun, desiredValue);
}

public class SetSlideInput : StateAction
{
	private readonly Moment _whenToRun;
	private readonly bool _desiredValue;
	private FgmInputHandler _fgmInputHandler;
	public SetSlideInput(Moment whenToRun, bool desiredValue)
    {
		_whenToRun = whenToRun;
		_desiredValue = desiredValue;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent<FgmInputHandler>(out _fgmInputHandler);
		if (_fgmInputHandler == null)
			Debug.LogError("The FgmInputHandler component cannot be found.");
	}
	
	public override void OnUpdate()
	{
		SetValue(SpecificMoment.OnUpdate, _desiredValue);
	}
	
	public override void OnStateEnter()
	{
		SetValue(SpecificMoment.OnStateEnter, _desiredValue);
	}
	
	public override void OnStateExit()
	{
		SetValue(SpecificMoment.OnStateExit, _desiredValue);
	}

	private void SetValue(Moment specifiedMoment, bool desiredValue)
    {
		if (specifiedMoment == _whenToRun)
			_fgmInputHandler.SlideInput = desiredValue;
    }
}
