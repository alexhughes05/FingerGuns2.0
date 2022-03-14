using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "SetAllowShooting", menuName = "State Machines/Actions/Set Allow Shooting")]
public class SetAllowShootingSO : StateActionSO
{
	[Space]
	public Moment whenToRun;
	[Space]
	[SerializeField]
	private bool allowShooting;
	protected override StateAction CreateAction() => new SetAllowShooting(whenToRun, allowShooting);
}

public class SetAllowShooting : StateAction
{
	private readonly bool _allowShooting;
	private readonly Moment _whenToRun;
	private FgmInputHandler _fgmInputHandler;

	public SetAllowShooting(Moment whenToRun, bool allowShooting)
    {
		_whenToRun = whenToRun;
		_allowShooting = allowShooting;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _fgmInputHandler);
		if (_fgmInputHandler == null)
			Debug.LogError("AllowShootingSO was unable to find the FgmInputHandler component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
		ModifyShootingFlash(SpecificMoment.OnUpdate);
	}
	
	public override void OnStateEnter()
	{
		ModifyShootingFlash(SpecificMoment.OnStateEnter);
	}
	
	public override void OnStateExit()
	{
		ModifyShootingFlash(SpecificMoment.OnStateExit);
	}

	public void ModifyShootingFlash(Moment specifiedMoment)
    {
		if (_whenToRun == specifiedMoment)
			_fgmInputHandler.AllowShooting = _allowShooting;
	}
}
