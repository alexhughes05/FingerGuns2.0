using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "TimeBtwSlidesTimerDone", menuName = "State Machines/Conditions/Time Btw Slides Timer Done")]
public class TimeBtwSlidesTimerDoneSO : StateConditionSO
{
	protected override Condition CreateCondition() => new TimeBtwSlidesTimerDone();
}

public class TimeBtwSlidesTimerDone : Condition
{
	private FgmSlideTimers _fgmSlideTimers;
	protected new TimeBtwSlidesTimerDoneSO OriginSO => (TimeBtwSlidesTimerDoneSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent<FgmSlideTimers>(out _fgmSlideTimers);
		if (_fgmSlideTimers == null)
			Debug.LogError("The FgmSlideTimers component cannot be found.");
	}
	
	protected override bool Statement()
	{
		return Time.time > _fgmSlideTimers.TimeWhenCanSlideAgain;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
