using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsMovingTowardsDirection", menuName = "State Machines/Conditions/Is Moving Towards Direction")]
public class IsMovingTowardsDirectionSO : StateConditionSO
{
	[SerializeField]
	private MovementDirections directionToVerify;
	protected override Condition CreateCondition() => new IsMovingTowardsDirection(directionToVerify);
}

public class IsMovingTowardsDirection : Condition
{
    private DirectionBehaviour _directionBehaviour;
	private Rigidbody2D _rb2d;
	private readonly MovementDirections _directionToVerify;
	public IsMovingTowardsDirection(MovementDirections directionToVerify)
    {
		_directionToVerify = directionToVerify;
    }

	public override void Awake(StateMachine stateMachine)
	{
		_directionBehaviour = stateMachine.GetComponent<DirectionBehaviour>();
		_rb2d = stateMachine.GetComponent<Rigidbody2D>();
	}
	
	protected override bool Statement()
	{
		bool movingInSpecifiedDirection = false;
		switch (_directionToVerify)
        {
			case (MovementDirections.Forwards):
                {
					if (_directionBehaviour.FacingDirection == XDirections.Left && _rb2d.velocity.x < 0 ||
					    _directionBehaviour.FacingDirection == XDirections.Right && _rb2d.velocity.x > 0)
                    {
						movingInSpecifiedDirection = true;
					} 
					break;
				}
			case (MovementDirections.Backwards):
				{
					if (_directionBehaviour.FacingDirection == XDirections.Left && _rb2d.velocity.x > 0 ||
						_directionBehaviour.FacingDirection == XDirections.Right && _rb2d.velocity.x < 0)
					{
						movingInSpecifiedDirection = true;
					}
					break;
				}
		}
		return movingInSpecifiedDirection;
	}
	
	public override void OnStateEnter() { }
	
	public override void OnStateExit() { }
}
public enum MovementDirections
{
	Forwards,
	Backwards
}
