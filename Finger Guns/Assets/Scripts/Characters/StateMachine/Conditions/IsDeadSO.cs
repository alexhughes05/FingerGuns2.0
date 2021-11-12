using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsDead", menuName = "State Machines/Conditions/Is Dead")]
public class IsDeadSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsDead();
}

public class IsDead : Condition
{
	private Health _health;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _health);
		if (_health == null)
			Debug.LogError("Unable to find the " + "Health component on the game object " + stateMachine.gameObject.name);
	}
	
	protected override bool Statement()
	{
		return _health.CurrentHealth <= 0;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
