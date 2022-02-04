using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsInvulnerable", menuName = "State Machines/Conditions/Is Invulnerable")]
public class IsInvulnerableSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsInvulnerable();
}

public class IsInvulnerable : Condition
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
		return damageable.Invulnerable;
	}
}
