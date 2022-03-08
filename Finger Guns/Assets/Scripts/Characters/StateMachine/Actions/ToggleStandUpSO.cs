using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ToggleStandUp", menuName = "State Machines/Actions/Toggle Stand Up")]
public class ToggleStandUpSO : StateActionSO
{
	[SerializeField] private float timeAfterGrounded;
	[SerializeField] private StandUpType standUpType;
	protected override StateAction CreateAction() => new ToggleStandUp(timeAfterGrounded, standUpType);
}

public class ToggleStandUp : StateAction
{
	private readonly float _timeAfterGrounded;
	private float _fallBackTimerEndTime;
	private StandUpType _standUpType;

	private GroundedChecker _groundedChecker;
	private Knockbackable _knockbackable;
	private Rigidbody2D _rb2d;
	public ToggleStandUp(float timeAfterGrounded, StandUpType standUpType)
	{
		_timeAfterGrounded = timeAfterGrounded;
		_standUpType = standUpType;
	}

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _rb2d);
		if (_rb2d == null)
			Debug.LogError("ToggleStandUpSO was unable to find the Rigidbody2D component on gameobject " + stateMachine.gameObject.name);

		stateMachine.TryGetComponent(out _knockbackable);
		if (_knockbackable == null)
			Debug.LogError("ToggleStandUpSO was unable to find the Knockbackable component on gameobject " + stateMachine.gameObject.name);

		stateMachine.TryGetComponent(out _groundedChecker);
		if (_groundedChecker == null)
			Debug.LogError("ToggleStandUpSO was unable to find the GroundChecker component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
		if (_fallBackTimerEndTime == -1 && _groundedChecker.Grounded)
			_fallBackTimerEndTime = Time.time + _timeAfterGrounded;

		if ((_fallBackTimerEndTime != -1 && Time.time >= _fallBackTimerEndTime && _groundedChecker.Grounded) || (_groundedChecker.Grounded && _rb2d.velocity.x == 0))
        {
			if (_standUpType == StandUpType.Normal)
				_knockbackable.StandUp = true;
			else
				_knockbackable.StandUpForward = true;
		}
	}
	
	public override void OnStateEnter()
	{
		_fallBackTimerEndTime = -1f;
	}
	
	public override void OnStateExit()
	{
		_fallBackTimerEndTime = -1f;
	}
}

public enum StandUpType
{
	Normal,
	Forward
}
