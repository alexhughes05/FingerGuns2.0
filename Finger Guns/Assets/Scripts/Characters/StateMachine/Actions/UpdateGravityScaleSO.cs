using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "UpdateGravityScale", menuName = "State Machines/Actions/Update Gravity Scale")]
public class UpdateGravityScaleSO : StateActionSO
{
	[SerializeField]
	private Moment whenToRun;
	[SerializeField]
	private bool resetBackToOriginalOnExit;
	[SerializeField]
	private float gravityScaleMultiplier;
	protected override StateAction CreateAction() => new UpdateGravityScale(whenToRun, gravityScaleMultiplier, resetBackToOriginalOnExit);
}

public class UpdateGravityScale : StateAction
{
	private readonly Moment _whenToRun;
	private readonly float _gravityScaleMultiplier;
	private readonly bool _resetBackToOriginalOnExit;
	private float _originalGravityScale;
	private Rigidbody2D _rb2d;
	public UpdateGravityScale(Moment whenToRun, float newGravityScale, bool resetBackToOriginalOnExit)
    {
		_whenToRun = whenToRun;
		_gravityScaleMultiplier = newGravityScale;
		_resetBackToOriginalOnExit = resetBackToOriginalOnExit;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _rb2d);
		if (_rb2d == null)
			Debug.LogError("The component Rigidbody2D cannot be found.");
	}
	
	public override void OnUpdate()
	{
		SetGravityScale(SpecificMoment.OnUpdate, _gravityScaleMultiplier);
	}
	
	public override void OnStateEnter()
	{
		SetGravityScale(SpecificMoment.OnStateEnter, _gravityScaleMultiplier);
	}
	
	public override void OnStateExit()
	{
		SetGravityScale(SpecificMoment.OnStateExit, _gravityScaleMultiplier);
		if (_resetBackToOriginalOnExit)
			_rb2d.gravityScale = _originalGravityScale;

	}

	private void SetGravityScale(Moment specificMoment, float gravityScaleMultiplier)
    {
		if (specificMoment == _whenToRun)
        {
			_originalGravityScale = _rb2d.gravityScale;
			_rb2d.gravityScale *= gravityScaleMultiplier;
		}
    }
}
