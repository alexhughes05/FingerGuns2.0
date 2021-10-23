using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsFalling", menuName = "State Machines/Conditions/Is Falling")]
public class IsFallingSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsFalling();
}

public class IsFalling : Condition
{
	private Rigidbody2D _rb2d;
	protected new IsFallingSO OriginSO => (IsFallingSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_rb2d = stateMachine.GetComponent<Rigidbody2D>();
	}
	
	protected override bool Statement()
	{
		return _rb2d.velocity.y < 0;
	}
	
	public override void OnStateEnter() { }
	
	public override void OnStateExit() { }
}
