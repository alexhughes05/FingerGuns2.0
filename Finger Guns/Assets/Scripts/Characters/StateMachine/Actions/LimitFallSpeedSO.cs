using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "LimitFallSpeed", menuName = "State Machines/Actions/Limit Fall Speed")]
public class LimitFallSpeedSO : StateActionSO
{
	[SerializeField]
	[Min(0.1f)]
	private float maxFallSpeed;
	protected override StateAction CreateAction() => new LimitFallSpeed(maxFallSpeed);
}

public class LimitFallSpeed : StateAction
{
	private readonly float _maxFallSpeed;
	private Rigidbody2D _rb2d;
	public LimitFallSpeed(float maxFallSpeed)
    {
		_maxFallSpeed = maxFallSpeed;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _rb2d);
		if (_rb2d == null)
			Debug.LogError("The component Rigidbody2D cannot be found.");
	}
	
	public override void OnUpdate()
	{
		if (_rb2d.velocity.magnitude > _maxFallSpeed)
			_rb2d.velocity = Vector2.ClampMagnitude(_rb2d.velocity, _maxFallSpeed);
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
