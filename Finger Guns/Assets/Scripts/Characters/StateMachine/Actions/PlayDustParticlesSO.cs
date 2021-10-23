using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "PlayDustParticles", menuName = "State Machines/Actions/Play Dust Particles")]
public class PlayDustParticlesSO : StateActionSO
{
	protected override StateAction CreateAction() => new PlayDustParticles();
}

public class PlayDustParticles : StateAction
{
	private FgmEffectsController _fgmEffectsController;

    public override void Awake(StateMachine stateMachine)
    {
		_fgmEffectsController = stateMachine.GetComponent<FgmEffectsController>();
    }
    public override void OnUpdate() { }
	public override void OnStateEnter()
	{
		_fgmEffectsController.EnableWalkParticles();
	}	
	public override void OnStateExit()
	{
		_fgmEffectsController.DisableWalkParticles();
	}
}
