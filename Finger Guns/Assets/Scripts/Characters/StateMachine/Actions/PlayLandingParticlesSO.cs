using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "PlayLandingParticles", menuName = "State Machines/Actions/Play Landing Particles")]
public class PlayLandingParticlesSO : StateActionSO
{
	protected override StateAction CreateAction() => new PlayLandingParticles();
}

public class PlayLandingParticles : StateAction
{
	private FgmEffectsController _fgmEffectsController;

	public override void Awake(StateMachine stateMachine)
	{
		_fgmEffectsController = stateMachine.GetComponent<FgmEffectsController>();
	}
	public override void OnUpdate() { }
	public override void OnStateEnter()
	{
		_fgmEffectsController.EnableLandingParticles();
	}
	public override void OnStateExit()
	{
		//_fgmEffectsController.DisableLandingParticles();
	}
}
