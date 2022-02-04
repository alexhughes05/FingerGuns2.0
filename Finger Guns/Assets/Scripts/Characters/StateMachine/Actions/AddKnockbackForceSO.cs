using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "AddKnockbackForce", menuName = "State Machines/Actions/Add Knockback Force")]
public class AddKnockbackForceSO : StateActionSO
{
	[Space]
	[SerializeField] private Moment whenToRun;
	protected override StateAction CreateAction() => new AddKnockbackForce(whenToRun);
}

public class AddKnockbackForce : StateAction
{
	private readonly Moment _whenToRun;

	private Rigidbody2D _rb2d;
	private Knockbackable _knockbackable;
	public AddKnockbackForce(Moment whenToRun)
    {
		_whenToRun = whenToRun;
    }
	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _knockbackable);
		if (_knockbackable == null)
			Debug.LogError("AddKnockbackForceSO was unable to find the Knockbackable component on gameobject " + stateMachine.gameObject.name);
		stateMachine.TryGetComponent(out _rb2d);
		if (_rb2d == null)
			Debug.LogError("AddKnockbackForceSO was unable to find the Rigidbody2D component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
		ApplyKnockbackForce(Moment.OnUpdate, _knockbackable.KnockbackVector);
	}
	
	public override void OnStateEnter()
	{
		ApplyKnockbackForce(Moment.OnStateEnter, _knockbackable.KnockbackVector);
	}
	
	public override void OnStateExit()
	{
		ApplyKnockbackForce(Moment.OnStateExit, _knockbackable.KnockbackVector);
	}

	private void ApplyKnockbackForce(Moment specifiedMoment, Vector3 knockbackForce)
    {
		if (specifiedMoment == _whenToRun)
			_rb2d.AddForce(knockbackForce, ForceMode2D.Impulse);
    }
}
