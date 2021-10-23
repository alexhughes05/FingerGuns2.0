using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "VerifyFacingDirection", menuName = "State Machines/Conditions/Verify Facing Direction")]
public class VerifyFacingDirectionSO : StateConditionSO
{
	[SerializeField]
	private XDirections facingDirection;
	protected override Condition CreateCondition() => new VerifyFacingDirection(facingDirection);
}

public class VerifyFacingDirection : Condition
{
	private DirectionBehaviour _directionBehaviour;
	private readonly XDirections _facingDirection;
	public VerifyFacingDirection(XDirections facingDirection)
    {
		_facingDirection = facingDirection;
    }
	public override void Awake(StateMachine stateMachine)
	{
		_directionBehaviour = stateMachine.GetComponent<DirectionBehaviour>();
	}
	
	protected override bool Statement()
	{
		return _facingDirection == _directionBehaviour.FacingDirection;
	}
	
	public override void OnStateEnter(){}
	
	public override void OnStateExit(){}
}
