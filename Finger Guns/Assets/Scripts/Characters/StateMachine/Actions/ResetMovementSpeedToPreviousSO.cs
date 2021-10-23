using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ResetMovementSpeedBackToPrevious", menuName = "State Machines/Actions/Reset Movement Speed Back To Previous")]
public class ResetMovementSpeedToPreviousSO : StateActionSO
{
	protected override StateAction CreateAction() => new ResetMovementSpeedToPrevious();
}

public class ResetMovementSpeedToPrevious : StateAction
{
	private MoveBehaviour _moveBehaviour;
	protected new ResetMovementSpeedToPreviousSO OriginSO => (ResetMovementSpeedToPreviousSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent<MoveBehaviour>(out _moveBehaviour);
		if (_moveBehaviour == null)
			Debug.LogError("The MoveBehaviour component could not be found.");
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
		_moveBehaviour.CurrentMaxSpeed = _moveBehaviour.PreviousMaxSpeed;
		_moveBehaviour.ApplyMovement();
	}
}
