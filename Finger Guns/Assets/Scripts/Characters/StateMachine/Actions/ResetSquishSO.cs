using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ResetSquish", menuName = "State Machines/Actions/Reset Squish")]
public class ResetSquishSO : StateActionSO
{
	protected override StateAction CreateAction() => new ResetSquish();
}

public class ResetSquish : StateAction
{
	private Squishable _squishable;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _squishable);
		if (_squishable == null)
			Debug.LogError("ResetSquishSO was unable to find the Squishable component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
		_squishable.ShouldSquish = false;
	}
	
	public override void OnStateExit()
	{
	}
}
