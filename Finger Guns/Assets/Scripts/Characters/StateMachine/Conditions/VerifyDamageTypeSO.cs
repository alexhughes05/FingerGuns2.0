using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "VerifyDamageType", menuName = "State Machines/Conditions/Verify Damage Type")]
public class VerifyDamageTypeSO : StateConditionSO
{
	[SerializeField] private DamageResponseSO desiredDamageType;
	protected override Condition CreateCondition() => new VerifyDamageType(desiredDamageType);
}

public class VerifyDamageType : Condition
{
	private readonly DamageResponseSO _desiredDamageType;
	private Damageable damageable;
	public VerifyDamageType(DamageResponseSO desiredDamagetype)
    {
		_desiredDamageType = desiredDamagetype;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out damageable);
		if (damageable == null)
			Debug.LogError("Error, the Damageable component could not be found on gameObject: " + stateMachine.gameObject);
	}
	
	protected override bool Statement()
	{
		return false;
		//return (damageable.DamageResponse == _desiredDamageType);
	}
}
