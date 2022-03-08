using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "SetVelocity", menuName = "State Machines/Actions/Set Velocity")]
public class SetVelocitySO : StateActionSO
{
	[Space]
	[SerializeField]
	private Moment whenToRun;
	[Space]
	[SerializeField]
	private float desiredVelocity;
	[Space]
	[SerializeField]
	private Axis applyToAxis;
	protected override StateAction CreateAction() => new SetVelocity(whenToRun, applyToAxis, desiredVelocity);
}

public class SetVelocity : StateAction
{
	private readonly Moment _whenToRun;
	private readonly Axis _applyToAxis;
	private readonly float _desiredVelocity;
	private Rigidbody2D _rb2d;
	private Vector2 _velocity;
	public SetVelocity(Moment whenToRun, Axis applyToAxis, float desiredVelocity)
    {
		_whenToRun = whenToRun;
		_applyToAxis = applyToAxis;
		_desiredVelocity = desiredVelocity;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent<Rigidbody2D>(out _rb2d);
		if (_rb2d == null)
			Debug.LogError("The Rigidbody2D component cannot be found.");
		_velocity = _rb2d.velocity;
	}
	
	public override void OnUpdate()
	{
		SetVelocityOfSpecifiedAxis(Moment.OnUpdate, _applyToAxis);
	}
	
	public override void OnStateEnter()
	{
		SetVelocityOfSpecifiedAxis(Moment.OnStateEnter, _applyToAxis);
	}
	
	public override void OnStateExit()
	{
		SetVelocityOfSpecifiedAxis(Moment.OnStateExit, _applyToAxis);
	}

	private void SetVelocityOfSpecifiedAxis(Moment specifiedMoment, Axis specifiedAxis)
    {
		if (specifiedMoment == _whenToRun)
        {
			switch (specifiedAxis)
            {
				case Axis.X:
                    {
						_velocity.x = _desiredVelocity;
						_velocity.y = _rb2d.velocity.y;
						_rb2d.velocity = _velocity;
                    }
					break;
				case Axis.Y:
					{
						_velocity.x = _rb2d.velocity.x;
						_velocity.y = _desiredVelocity;
						_rb2d.velocity = _velocity;
					}
					break;
				case Axis.XY:
					{
						_velocity.x = _desiredVelocity;
						_velocity.y = _desiredVelocity;
						_rb2d.velocity = _velocity;
					}
					break;
			}
        }
    }
}
public enum Axis
{
	X,
	Y,
	XY,
}

