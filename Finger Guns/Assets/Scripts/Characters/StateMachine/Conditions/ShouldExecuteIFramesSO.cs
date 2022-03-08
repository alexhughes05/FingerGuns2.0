using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ShouldExecuteIFrames", menuName = "State Machines/Conditions/Should Execute IFrames")]
public class ShouldExecuteIFramesSO : StateConditionSO
{
	protected override Condition CreateCondition() => new ShouldExecuteIFrames();
}

public class ShouldExecuteIFrames : Condition
{
	private MaterialModifier _materialModifier;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _materialModifier);
		if (_materialModifier == null)
			Debug.LogError("ShouldExecuteIFrames was unable to find the MaterialModifier component on gameobject " + stateMachine.gameObject.name);
	}
	
	protected override bool Statement()
	{
		return _materialModifier.ExecuteIFrames;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
