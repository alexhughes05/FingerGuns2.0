using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "SetInvulnerable", menuName = "State Machines/Actions/Set Invulnerable")]
public class SetInvulnerableSO : StateActionSO
{
	[SerializeField] private Moment whenToRun = default;
	[SerializeField] private bool isInvulnerable;
	protected override StateAction CreateAction() => new SetInvulnerable(whenToRun, isInvulnerable);
}

public class SetInvulnerable : StateAction
{
	private readonly Moment _whenToRun;
	private readonly bool _isInvulnerable;
	private Damageable damageable;

	public SetInvulnerable(Moment whenToRun, bool isInvulnerable)
    {
		_whenToRun = whenToRun;
		_isInvulnerable = isInvulnerable;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out damageable);
		if (damageable == null)
			Debug.LogError("Unable to find component Damageable on gameObject " + stateMachine.gameObject);
	}
	
	public override void OnStateEnter()
	{
		if (_whenToRun == Moment.OnStateEnter)
			damageable.Invulnerable = _isInvulnerable;
	}

    public override void OnUpdate()
    {
		if (_whenToRun == Moment.OnUpdate)
			damageable.Invulnerable = _isInvulnerable;
	}

    public override void OnStateExit()
	{
		if (_whenToRun == Moment.OnStateExit)
			damageable.Invulnerable = _isInvulnerable;
	}
}
