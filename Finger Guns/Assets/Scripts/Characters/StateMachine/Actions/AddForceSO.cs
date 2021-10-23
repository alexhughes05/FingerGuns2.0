using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "AddForce", menuName = "State Machines/Actions/Add Force")]
public class AddForceSO : StateActionSO
{
	[Space]
	[SerializeField]
	private Moment whenToRun;
	[Space]
	[SerializeField]
	private bool applyForceInFacingDirection;
	[SerializeField]
	private bool additiveToCurrentMaxSpeed;
	[Space]
	[SerializeField]
	private Vector2 forceVector;
	[SerializeField]
	private ForceMode2D forceMode;

	protected override StateAction CreateAction() => new AddForce(whenToRun, forceVector, forceMode, applyForceInFacingDirection, additiveToCurrentMaxSpeed);
}

public class AddForce : StateAction
{
    private readonly Moment _whenToRun;
	private readonly bool _applyForceInFacingDirection;
	private readonly bool _additiveToCurrentMaxSpeed;
	private readonly ForceMode2D _forceMode;
	private Vector2 _forceVector;
	private Rigidbody2D _rb2d;
	private MoveBehaviour _moveBehaviour;
	private DirectionBehaviour _directionBehaviour;

	public AddForce(Moment whenToRun, Vector2 forceVector, ForceMode2D forceMode, bool applyForceInFacingDirection, bool additiveToCurrentMaxSpeed)
    {
		_whenToRun = whenToRun;
		_forceMode = forceMode;
		_forceVector = forceVector;
		_applyForceInFacingDirection = applyForceInFacingDirection;
		_additiveToCurrentMaxSpeed = additiveToCurrentMaxSpeed;
    }
	protected new AddForceSO OriginSO => (AddForceSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_rb2d = stateMachine.GetComponent<Rigidbody2D>();
		if (_applyForceInFacingDirection)
        {
			stateMachine.TryGetComponent<DirectionBehaviour>(out _directionBehaviour);
			if (_directionBehaviour == null)
				Debug.LogError("The Direction Behaviour component cannot be found.");
        }
		if (_additiveToCurrentMaxSpeed)
        {
			stateMachine.TryGetComponent<MoveBehaviour>(out _moveBehaviour);
			if (_moveBehaviour == null)
				Debug.LogError("The Move Behaviour component cannot be found.");
		}
	}
	
	public override void OnUpdate() 
	{
		ApplyForce(SpecificMoment.OnUpdate, _applyForceInFacingDirection, _additiveToCurrentMaxSpeed);
	}
	
	public override void OnStateEnter() 
	{
		ApplyForce(SpecificMoment.OnStateEnter, _applyForceInFacingDirection, _additiveToCurrentMaxSpeed);
	}
	public override void OnStateExit() 
	{
		ApplyForce(SpecificMoment.OnStateExit, _applyForceInFacingDirection, _additiveToCurrentMaxSpeed);
	}

	private void ApplyForce(Moment specifiedMoment, bool applyInFacingDirection, bool additiveToCurrentMaxSpeed)
    {
		if (_whenToRun == specifiedMoment)
        {
			if (applyInFacingDirection)
                UpdateForceBasedOnDirection();

			if (additiveToCurrentMaxSpeed)
            {
				var originalForceXValue = _forceVector.x;
				UpdateForceBasedOnCurrentMaxSpeed();
				SetVelocityToZeroAndAddForce();
				_forceVector.x = originalForceXValue;
			}
			else
				SetVelocityToZeroAndAddForce();
		}
	}

    private void UpdateForceBasedOnDirection()
    {
        switch (_directionBehaviour.FacingDirection)
        {
            case XDirections.Left:
                if (_forceVector.x > 0) _forceVector.x *= -1;
                break;
            case XDirections.Right:
                if (_forceVector.x < 0) _forceVector.x *= -1;
                break;
            default:
                _forceVector.x = 0;
                break;
        }
    }

	private void UpdateForceBasedOnCurrentMaxSpeed()
    {
		switch (_moveBehaviour.CurrentMovementDirection)
		{
			case XDirections.Left:
				_forceVector.x += _moveBehaviour.CurrentMaxSpeed * -1;
				break;
			case XDirections.Right:
				_forceVector.x += _moveBehaviour.CurrentMaxSpeed;
				break;
			case XDirections.None: _forceVector.x += (_forceVector.x >= 0) ? _moveBehaviour.CurrentMaxSpeed : _moveBehaviour.CurrentMaxSpeed * -1; //NEED TO CHANGE THIS
				break;
		}
	}

    private void SetVelocityToZeroAndAddForce()
    {
		_rb2d.velocity = Vector2.zero;
		_rb2d.AddForce(_forceVector, _forceMode);
	}
}
