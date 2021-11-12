using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "TriggerGameEvent", menuName = "State Machines/Actions/Trigger Game Event")]
public class TriggerGameEventSO : StateActionSO
{
	public GameEvent gameEvent;
	protected override StateAction CreateAction() => new TriggerGameEvent();
}

public class TriggerGameEvent : StateAction
{
	protected new TriggerGameEventSO OriginSO => (TriggerGameEventSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
		OriginSO.gameEvent.Raise();
	}
	
	public override void OnStateExit()
	{
	}
}
