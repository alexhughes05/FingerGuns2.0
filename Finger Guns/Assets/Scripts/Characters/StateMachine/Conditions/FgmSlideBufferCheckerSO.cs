using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "FgmSlideBufferChecker", menuName = "State Machines/Conditions/Fgm Slide Buffer Checker")]
public class FgmSlideBufferCheckerSO : StateConditionSO
{
	[SerializeField]
	private float slideBufferWindow;
	protected override Condition CreateCondition() => new FgmSlideBufferChecker(slideBufferWindow);
}

public class FgmSlideBufferChecker : Condition
{
	private readonly float _slideBufferWindow;
	private bool _hadSlideInputWhenGrounded;
	private FgmInputHandler _fgmInputHandler;
	public FgmSlideBufferChecker(float slideBufferWindow)
	{
		_slideBufferWindow = slideBufferWindow;
	}

	public override void Awake(StateMachine stateMachine)
	{
		_fgmInputHandler = stateMachine.GetComponent<FgmInputHandler>();
	}

	protected override bool Statement()
	{
		if (_hadSlideInputWhenGrounded)
			return true;

		var finalBufferTime = _fgmInputHandler.SlideTimeStamp + _slideBufferWindow;
		if (Time.time < finalBufferTime)
		{
			_hadSlideInputWhenGrounded = true;
			return true;
		}
		else
        {
			_fgmInputHandler.SlideInput = false;
			return false;
        }
	}

	public override void OnStateEnter() 
	{
		_hadSlideInputWhenGrounded = false;
	}

	public override void OnStateExit()
	{
		_hadSlideInputWhenGrounded = false;
	}
}
