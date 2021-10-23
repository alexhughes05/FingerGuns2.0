using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "MaxSlideDurationCheck", menuName = "State Machines/Actions/Max Slide Duration Check")]
public class MaxSlideDurationCheckSO : StateActionSO
{
	protected override StateAction CreateAction() => new MaxSlideDurationCheck();
}

public class MaxSlideDurationCheck : StateAction
{
	private FgmSlideTimers _fgmSlideTimers;
	private FgmInputHandler _fgmInputHandler;

	public override void Awake(StateMachine stateMachine)
	{
		_fgmSlideTimers = stateMachine.GetComponent<FgmSlideTimers>();
		_fgmInputHandler = stateMachine.GetComponent<FgmInputHandler>();
	}
	public override void OnUpdate() 
	{
		if (_fgmSlideTimers.TimeWhenSlideEnds != 0 && _fgmSlideTimers.TimeWhenSlideEnds <= Time.time)
			_fgmInputHandler.SlideInput = false;
	}

	public override void OnStateEnter(){}
	public override void OnStateExit() { }
}
