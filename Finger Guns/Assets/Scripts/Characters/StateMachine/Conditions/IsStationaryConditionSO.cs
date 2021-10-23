using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsStationaryCondition", menuName = "State Machines/Conditions/Is Stationary Condition")]
public class IsStationaryConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsStationaryCondition();
}

public class IsStationaryCondition : Condition
{
	private FgmInputHandler _fgmInputHandler;
	private Rigidbody2D _rb2d;
	protected new IsStationaryConditionSO OriginSO => (IsStationaryConditionSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_fgmInputHandler = stateMachine.GetComponent<FgmInputHandler>();
		_rb2d = stateMachine.GetComponent<Rigidbody2D>();
	}
	
	protected override bool Statement()
	{
		if (_rb2d.velocity.y != 0)
			return false;
		else
			return _fgmInputHandler.MovingInput == false;
	}
	
	public override void OnStateEnter() { }
	
	public override void OnStateExit() { }
}
