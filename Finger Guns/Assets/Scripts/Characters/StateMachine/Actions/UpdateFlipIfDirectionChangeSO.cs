using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "UpdateFlipIfDirectionChange", menuName = "State Machines/Actions/Update Flip If Direction Change")]
public class UpdateFlipIfDirectionChangeSO : StateActionSO
{
	protected override StateAction CreateAction() => new UpdateFlipIfDirectionChange();
}

public class UpdateFlipIfDirectionChange : StateAction
{
	private Rigidbody2D _rb2d;
	private DirectionBehaviour _directionBehaviour;
	private FgmInputHandler _fgmInputHandler;
	protected new UpdateFlipIfDirectionChangeSO OriginSO => (UpdateFlipIfDirectionChangeSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _rb2d);
		if (_rb2d == null)
			Debug.LogError("The Rigidbody2D component could not be found for gameobject " + stateMachine.gameObject);

		stateMachine.TryGetComponent(out _directionBehaviour);
		if (_directionBehaviour == null)
			Debug.LogError("The DirectionBehaviour component could not be found for gameobject " + stateMachine.gameObject);

		stateMachine.TryGetComponent(out _fgmInputHandler);
		if (_fgmInputHandler == null)
			Debug.LogError("The FgmInputHandler component could not be found for gameobject " + stateMachine.gameObject);
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
		if (_fgmInputHandler.SomersaultInput)
        {
			if (_rb2d.velocity.x > 0 && _directionBehaviour.FacingDirection == XDirections.Left || _rb2d.velocity.x < 0 && _directionBehaviour.FacingDirection == XDirections.Right)
			{
				_fgmInputHandler.BackflipInput = true;
				_fgmInputHandler.SomersaultInput = false;
			}
		}
		else if (_fgmInputHandler.BackflipInput)
        {
			if (_rb2d.velocity.x > 0 && _directionBehaviour.FacingDirection == XDirections.Right || _rb2d.velocity.x < 0 && _directionBehaviour.FacingDirection == XDirections.Left)
            {
				_fgmInputHandler.BackflipInput = false;
				_fgmInputHandler.SomersaultInput = true;
			}
		}
	}
}
