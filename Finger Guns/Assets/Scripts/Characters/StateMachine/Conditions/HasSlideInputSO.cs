using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "HasSlideInputSO", menuName = "State Machines/Conditions/Has Slide Input")]
public class HasSlideInputSO : StateConditionSO
{
	protected override Condition CreateCondition() => new HasSlideInput();
}

public class HasSlideInput : Condition
{
	private FgmInputHandler _fgmInputHandler;
	public override void Awake(StateMachine stateMachine)
	{
		_fgmInputHandler = stateMachine.GetComponent<FgmInputHandler>();
	}

	protected override bool Statement()
	{
		return _fgmInputHandler.SlideInput;
	}

	public override void OnStateEnter() { }

	public override void OnStateExit() { }
}
