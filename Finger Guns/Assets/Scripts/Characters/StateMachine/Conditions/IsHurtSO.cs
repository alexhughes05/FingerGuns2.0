using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsHurt", menuName = "State Machines/Conditions/Is Hurt")]
public class IsHurtSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsHurt();
}

public class IsHurt : Condition
{
	private Damageable damageable;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out damageable);
		if (damageable == null)
			Debug.LogError("Unable to find component Damageable on gameObject " + stateMachine.gameObject);
	}
	
	protected override bool Statement()
	{
		return damageable.TookDamage;
	}

	public override void OnStateExit()
    {
		if (damageable.TookDamage)
			damageable.TookDamage = false;
    }
}
