using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "StartMaxSlideDurationTimer", menuName = "State Machines/Actions/Start Max Slide Duration Timer")]
public class StartMaxSlideDurationTimerSO : StateActionSO
{
	protected override StateAction CreateAction() => new StartMaxSlideDurationTimer();
}

public class StartMaxSlideDurationTimer : StateAction
{
	private FgmSlideTimers _fgmSlideTimers;

	public override void Awake(StateMachine stateMachine)
	{
		_fgmSlideTimers = stateMachine.GetComponent<FgmSlideTimers>();
	}
	public override void OnUpdate() { }
	
	public override void OnStateEnter()
	{
		_fgmSlideTimers.StartMaxSlideDurationTimer();
	}	
	public override void OnStateExit() { }
}
