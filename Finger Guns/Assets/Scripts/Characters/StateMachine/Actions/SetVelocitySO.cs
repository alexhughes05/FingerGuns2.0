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
	private VelocityAxis applyToAxis;
	protected override StateAction CreateAction() => new SetVelocity(whenToRun, applyToAxis, desiredVelocity);
}

public class SetVelocity : StateAction
{
	private readonly Moment _whenToRun;
	private readonly VelocityAxis _applyToAxis;
	private readonly float _desiredVelocity;
	private Rigidbody2D _rb2d;
	private Vector2 _velocity;
	public SetVelocity(Moment whenToRun, VelocityAxis applyToAxis, float desiredVelocity)
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
		SetVelocityOfSpecifiedAxis(SpecificMoment.OnUpdate, _applyToAxis);
	}
	
	public override void OnStateEnter()
	{
		SetVelocityOfSpecifiedAxis(SpecificMoment.OnStateEnter, _applyToAxis);
	}
	
	public override void OnStateExit()
	{
		SetVelocityOfSpecifiedAxis(SpecificMoment.OnStateExit, _applyToAxis);
	}

	private void SetVelocityOfSpecifiedAxis(Moment specifiedMoment, VelocityAxis specifiedAxis)
    {
		if (specifiedMoment == _whenToRun)
        {
			switch (specifiedAxis)
            {
				case VelocityAxis.X:
                    {
						_velocity.x = _desiredVelocity;
						_velocity.y = _rb2d.velocity.y;
						_rb2d.velocity = _velocity;
                    }
					break;
				case VelocityAxis.Y:
					{
						_velocity.x = _rb2d.velocity.x;
						_velocity.y = _desiredVelocity;
						_rb2d.velocity = _velocity;
					}
					break;
				case VelocityAxis.XY:
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
public enum VelocityAxis
{
	X,
	Y,
	XY,
}

