using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "VerifyInputDirection", menuName = "State Machines/Conditions/Verify Input Direction")]
public class VerifyInputDirectionSO : StateConditionSO
{
	[SerializeField]
	private Directions2D direction;
	protected override Condition CreateCondition() => new VerifyInputDirection(direction);
}

public class VerifyInputDirection : Condition
{
	private Directions2D _direction;
	private Rigidbody2D _rb2d;


	public VerifyInputDirection(Directions2D direction) => _direction = direction;

	public override void Awake(StateMachine stateMachine)
	{
		_rb2d = stateMachine.GetComponent<Rigidbody2D>();
	}
	
	protected override bool Statement()
	{
		bool velocityMatchesDirection = false;
		switch (_direction)
        {
			case Directions2D.PositiveY: velocityMatchesDirection = _rb2d.velocity.y > 0;
                break;
			case Directions2D.NegativeY: velocityMatchesDirection = _rb2d.velocity.y < 0;
				break;
			case Directions2D.NegativeX: velocityMatchesDirection = _rb2d.velocity.x < 0;
				break;
			case Directions2D.PositiveX: velocityMatchesDirection = _rb2d.velocity.x > 0;
				break;
			case Directions2D.Stationary: velocityMatchesDirection = _rb2d.velocity.y == 0 && _rb2d.velocity.x == 0;
				break;
		}
		return velocityMatchesDirection;
	}
	
	public override void OnStateEnter() { }

	
	public override void OnStateExit() { }
}
