using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

/// <summary>
/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
/// </summary>
[CreateAssetMenu(fileName = "AnimatorParameterAction", menuName = "State Machines/Actions/Set Animator Parameter")]
public class AnimatorParameterActionSO : StateActionSO
{
	public ParameterType parameterType = default;
	public string parameterName = default;

	public bool boolValue = default;
	public int intValue = default;
	public float floatValue = default;

	public bool usedInStateMachine = true;
	public Moment whenToRun = default; // Allows this StateActionSO type to be reused for all 3 state moments

	private int _parameterHash;

    private void OnEnable()
    {
		_parameterHash = Animator.StringToHash(parameterName);
	}

    protected override StateAction CreateAction() => new AnimatorParameterAction();

	public void SetParameter(Animator _animator)
    {
		switch (parameterType)
		{
			case ParameterType.Bool:
				_animator.SetBool(_parameterHash, boolValue);
				break;
			case ParameterType.Int:
				_animator.SetInteger(_parameterHash, intValue);
				break;
			case ParameterType.Float:
				_animator.SetFloat(_parameterHash, floatValue);
				break;
			case ParameterType.Trigger:
				_animator.SetTrigger(_parameterHash);
				break;
		}
	}
}

public class AnimatorParameterAction : StateAction
{
	//Component references
	private Animator _animator;
	
	private AnimatorParameterActionSO _originSO => (AnimatorParameterActionSO)base.OriginSO; // The SO this StateAction spawned from

	public override void Awake(StateMachine stateMachine)
	{
		_animator = stateMachine.GetComponent<Animator>();
	}

	public override void OnStateEnter()
	{
        {
			if (_originSO.whenToRun == SpecificMoment.OnStateEnter)
            {
				_originSO.SetParameter(_animator);
			}
		}
	}

	public override void OnStateExit()
	{
		if (_originSO.whenToRun == SpecificMoment.OnStateExit)
			_originSO.SetParameter(_animator);
	}

	public override void OnUpdate() { }
}
