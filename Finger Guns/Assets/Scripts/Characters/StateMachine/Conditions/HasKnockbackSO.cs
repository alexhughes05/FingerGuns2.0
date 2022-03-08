using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "HasKnockback", menuName = "State Machines/Conditions/Has Knockback")]
public class HasKnockbackSO : StateConditionSO
{
	[SerializeField] private XDirections direction;
	protected override Condition CreateCondition() => new HasKnockback(direction);
}

public class HasKnockback : Condition
{
	private XDirections _direction;
	private Knockbackable _knockbackable;

	public HasKnockback(XDirections direction)
    {
		_direction = direction;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _knockbackable);
		if (_knockbackable == null)
			Debug.LogError("HasLeftKnockbackSO was unable to find the Knockbackable component on gameobject " + stateMachine.gameObject.name);
	}
	
	protected override bool Statement()
	{
		if (_direction == XDirections.Left)
			return _knockbackable.LeftKnockback;
		else if (_direction == XDirections.Right)
			return _knockbackable.RightKnockback;
		else
			return _knockbackable.NoHorizontalKnockback;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
