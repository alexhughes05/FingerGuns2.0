using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ResetKnockback", menuName = "State Machines/Actions/Reset Knockback")]
public class ResetKnockbackSO : StateActionSO
{
	protected override StateAction CreateAction() => new ResetKnockback();
}

public class ResetKnockback : StateAction
{
	private Knockbackable _knockbackable;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _knockbackable);
		if (_knockbackable == null)
			Debug.LogError("AddKnockbackForceSO was unable to find the Knockbackable component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
		_knockbackable.LeftKnockback = false;
		_knockbackable.RightKnockback = false;
	}
	
	public override void OnStateExit()
	{
	}
}
