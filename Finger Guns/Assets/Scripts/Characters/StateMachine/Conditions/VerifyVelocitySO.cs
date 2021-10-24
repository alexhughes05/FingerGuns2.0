using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "VerifyVelocity", menuName = "State Machines/Conditions/Verify Velocity")]
public class VerifyVelocitySO : StateConditionSO
{
	[Header("Current velocity is:")]
	[SerializeField]
	private Comparison comparison;
	[SerializeField]
	private float velocityToVerify;
	[Header("On the Axis:")]
	[SerializeField]
	private Axis axis;

	protected override Condition CreateCondition() => new VerifyVelocity(comparison, velocityToVerify, axis);
}

public class VerifyVelocity : Condition
{
	private readonly Comparison _comparison;
	private readonly float _velocityToVerify;
	private readonly Axis _axis;
	private Rigidbody2D _rb2d;
	public VerifyVelocity(Comparison comparison, float velocityToVerify, Axis axis)
    {
		_comparison = comparison;
		_velocityToVerify = velocityToVerify;
		_axis = axis;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _rb2d);
		if (_rb2d == null)
			Debug.LogError("Component Rigidbody2D could not be found.");
	}
	
	protected override bool Statement()
	{
		var result = ExpressionResult();
		Debug.Log(result);
		return result;
	}
	
	public override void OnStateEnter()
	{
		Debug.Log("entered.");
	}
	
	public override void OnStateExit()
	{
	}

	private bool ExpressionResult()
    {
		bool expressionResult = false;
		switch (_comparison)
        {
			case Comparison.EqualTo:
				switch (_axis)
                {
					case Axis.X:
						expressionResult = _rb2d.velocity.x == _velocityToVerify;
						break;
					case Axis.Y:
						expressionResult = _rb2d.velocity.y == _velocityToVerify;
						break;
					case Axis.XY:
						expressionResult = _rb2d.velocity.x == _velocityToVerify && _rb2d.velocity.y == _velocityToVerify;
						break;
				}
				break;
			case Comparison.LessThan:
				switch (_axis)
				{
					case Axis.X:
						expressionResult = _rb2d.velocity.x < _velocityToVerify;
						break;
					case Axis.Y:
						expressionResult = _rb2d.velocity.y < _velocityToVerify;
						break;
					case Axis.XY:
						expressionResult = _rb2d.velocity.x < _velocityToVerify && _rb2d.velocity.y < _velocityToVerify;
						break;
				}
				break;
			case Comparison.GreaterThan:
				switch (_axis)
				{
					case Axis.X:
						expressionResult = _rb2d.velocity.x > _velocityToVerify;
						break;
					case Axis.Y:
						expressionResult = _rb2d.velocity.y > _velocityToVerify;
						break;
					case Axis.XY:
						expressionResult = _rb2d.velocity.x > _velocityToVerify && _rb2d.velocity.y > _velocityToVerify;
						break;
				}
				break;
		}

		return expressionResult;
    }
}

public enum Comparison
{
	GreaterThan,
	LessThan,
	EqualTo
}
