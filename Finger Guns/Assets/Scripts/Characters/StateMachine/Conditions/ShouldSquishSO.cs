using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ShouldSquish", menuName = "State Machines/Conditions/Should Squish")]
public class ShouldSquishSO : StateConditionSO
{
	protected override Condition CreateCondition() => new ShouldSquish();
}

public class ShouldSquish : Condition
{
	private Squishable _squishable;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _squishable);
		if (_squishable == null)
			Debug.LogError("ShouldSquishSO was unable to find the Squishable component on gameobject " + stateMachine.gameObject.name);
	}
	
	protected override bool Statement()
	{
		return _squishable.ShouldSquish;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
