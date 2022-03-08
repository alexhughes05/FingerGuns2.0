using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "KnockbackVectorComparison", menuName = "State Machines/Conditions/Knockback Vector Comparison")]
public class KnockbackVectorComparisonSO : StateConditionSO
{
	[Header("Current Knockback vector is:")]
	[SerializeField]
	private Comparison comparison;
	[SerializeField]
	private float value;
	[Header("On the Axis:")]
	[SerializeField]
	private Axis axis;
	protected override Condition CreateCondition() => new KnockbackVectorComparison(comparison, value, axis);
}

public class KnockbackVectorComparison : Condition
{
	private readonly Comparison _comparison;
	private readonly float _value;
	private readonly Axis _axis;

	private Knockbackable _knockbackable;

	public KnockbackVectorComparison(Comparison comparison, float value, Axis axis)
    {
		_comparison = comparison;
		_value = value;
		_axis = axis;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _knockbackable);
		if (_knockbackable == null)
			Debug.LogError("Component Knockbackable could not be found.");
	}
	
	protected override bool Statement()
	{
		return ExpressionResult();
	}
	
	public override void OnStateEnter()
	{
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
						expressionResult = _knockbackable.KnockbackVector.x == _value;
						break;
					case Axis.Y:
						expressionResult = _knockbackable.KnockbackVector.y == _value;
						break;
					case Axis.XY:
						expressionResult = _knockbackable.KnockbackVector.x == _value && _knockbackable.KnockbackVector.y == _value;
						break;
				}
				break;
			case Comparison.LessThan:
				switch (_axis)
				{
					case Axis.X:
						expressionResult = _knockbackable.KnockbackVector.x < _value;
						break;
					case Axis.Y:
						expressionResult = _knockbackable.KnockbackVector.y < _value;
						break;
					case Axis.XY:
						expressionResult = _knockbackable.KnockbackVector.x < _value && _knockbackable.KnockbackVector.y < _value;
						break;
				}
				break;
			case Comparison.GreaterThan:
				switch (_axis)
				{
					case Axis.X:
						expressionResult = _knockbackable.KnockbackVector.x > _value;
						break;
					case Axis.Y:
						expressionResult = _knockbackable.KnockbackVector.y > _value;
						break;
					case Axis.XY:
						expressionResult = _knockbackable.KnockbackVector.x > _value && _knockbackable.KnockbackVector.y > _value;
						break;
				}
				break;
		}

		return expressionResult;
	}
}
