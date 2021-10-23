using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsAfk", menuName = "State Machines/Conditions/Is Afk")]
public class IsAfkSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsAfk();
}

public class IsAfk : Condition
{
	private AfkChecker _afkChecker;
	protected new IsAfkSO OriginSO => (IsAfkSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_afkChecker = stateMachine.GetComponent<AfkChecker>();
	}
	
	protected override bool Statement()
	{
		return _afkChecker.IsAfk;
	}
	
	public override void OnStateEnter() { }
	
	public override void OnStateExit() { }
}
