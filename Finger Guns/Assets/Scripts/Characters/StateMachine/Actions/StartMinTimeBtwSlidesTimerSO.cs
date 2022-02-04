using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "StartMinTimeBtwSlidesTimer", menuName = "State Machines/Actions/Start Min Time Btw Slides Timer")]
public class StartMinTimeBtwSlidesTimerSO : StateActionSO
{
	protected override StateAction CreateAction() => new StartMinTimeBtwSlidesTimer();
}

public class StartMinTimeBtwSlidesTimer : StateAction
{
	private FgmSlideTimers _fgmSlideTimers;
	private FgmInputHandler _fgmInputHandler;

	public override void Awake(StateMachine stateMachine)
	{
		_fgmSlideTimers = stateMachine.GetComponent<FgmSlideTimers>();
		_fgmInputHandler = stateMachine.GetComponent<FgmInputHandler>();
	}
	public override void OnUpdate() { }

	public override void OnStateEnter() { }
	public override void OnStateExit() 
	{
		_fgmSlideTimers.TimeWhenSlideEnds = 0f;
		_fgmSlideTimers.StartTimeBtwSlidesTimer();
		_fgmInputHandler.SlideInput = false;
	}
}
