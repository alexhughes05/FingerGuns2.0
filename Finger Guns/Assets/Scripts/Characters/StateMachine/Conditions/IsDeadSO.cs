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
	private Damageable _damageable;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _damageable);
		if (_damageable == null)
			Debug.LogError("IsDeadSO was unable to find the Damageable component on gameobject " + stateMachine.gameObject.name);
	}
	
	protected override bool Statement()
	{
		return _damageable.IsDead;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
