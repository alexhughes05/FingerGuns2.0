using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ResetFlipBools", menuName = "State Machines/Actions/Reset Flip Bools")]
public class ResetFlipBoolsSO : StateActionSO
{
	protected override StateAction CreateAction() => new ResetFlipBools();
}

public class ResetFlipBools : StateAction
{
	private FgmInputHandler _fgmInputHandler;
	protected new ResetFlipBoolsSO OriginSO => (ResetFlipBoolsSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _fgmInputHandler);
		if (_fgmInputHandler == null)
			Debug.LogError("ResetFlipBoolsSO was unable to find the FgmInputHandler component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
		_fgmInputHandler.SomersaultInput = false;
		_fgmInputHandler.BackflipInput = false;
	}
	
	public override void OnStateExit()
	{
	}
}
