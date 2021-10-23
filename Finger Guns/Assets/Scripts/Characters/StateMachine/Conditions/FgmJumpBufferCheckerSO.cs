using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "FgmJumpBufferChecker", menuName = "State Machines/Conditions/Fgm Jump Buffer Checker")]
public class FgmJumpBufferCheckerSO : StateConditionSO
{
	[SerializeField]
	private float jumpBufferWindow;

	protected override Condition CreateCondition() => new FgmJumpBufferChecker(jumpBufferWindow);
}

public class FgmJumpBufferChecker : Condition
{
	private readonly float _jumpBufferWindow;
	private bool _hadJumpInputWhenGrounded;
	private FgmInputHandler _fgmInputHandler;

	protected new FgmJumpBufferCheckerSO OriginSO => (FgmJumpBufferCheckerSO)base.OriginSO;
	public FgmJumpBufferChecker(float jumpBufferWindow)
    {
		_jumpBufferWindow = jumpBufferWindow;
    }

	public override void Awake(StateMachine stateMachine)
	{
		_fgmInputHandler = stateMachine.GetComponent<FgmInputHandler>();
	}
	
	protected override bool Statement()
	{
		if (_hadJumpInputWhenGrounded)
			return true;

		var finalBufferTime = _fgmInputHandler.JumpTimeStamp + _jumpBufferWindow;
		if (Time.time < finalBufferTime)
        {
			_hadJumpInputWhenGrounded = true;
			return true;
		}
		else
			return false;
	}
	
	public override void OnStateEnter() 
	{
		_hadJumpInputWhenGrounded = false;
	}

	public override void OnStateExit() 
	{
		_hadJumpInputWhenGrounded = false;
	}
}

