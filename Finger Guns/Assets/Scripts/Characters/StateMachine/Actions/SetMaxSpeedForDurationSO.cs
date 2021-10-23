using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "SetMaxSpeedForDuration", menuName = "State Machines/Actions/Set Max Speed For Duration")]
public class SetMaxSpeedForDurationSO : StateActionSO
{
	[SerializeField]
	private bool additiveToCurrentMaxSpeed;
	[SerializeField]
	private float newMaxSpeed;
	[SerializeField]
	private float duration;
	protected override StateAction CreateAction() => new SetSpeedForDuration();
}

public class SetSpeedForDuration : StateAction
{
	protected new SetMaxSpeedForDurationSO OriginSO => (SetMaxSpeedForDurationSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
