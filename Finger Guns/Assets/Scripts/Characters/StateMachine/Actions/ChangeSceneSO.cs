using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ChangeScene", menuName = "State Machines/Actions/Change Scene")]
public class ChangeSceneSO : StateActionSO
{
	[SerializeField]
	private string sceneName;
	protected override StateAction CreateAction() => new ChangeScene();
}

public class ChangeScene : StateAction
{
	protected new ChangeSceneSO OriginSO => (ChangeSceneSO)base.OriginSO;

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
