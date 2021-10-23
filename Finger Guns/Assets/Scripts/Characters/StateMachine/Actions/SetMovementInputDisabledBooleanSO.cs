using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "SetMovementInputDisabledBoolean", menuName = "State Machines/Actions/Set Movement Input Disabled Boolean")]
public class SetMovementInputDisabledBooleanSO : StateActionSO
{
    [Space]
    [SerializeField]
    private Moment whenToRun;
    [Space]
    [SerializeField] bool desiredValue;
    protected override StateAction CreateAction() => new SetMovementInputDisabledBoolean(whenToRun, desiredValue);
}

public class SetMovementInputDisabledBoolean : StateAction
{
    private Moment _whenToRun;
    private bool _desiredValue;
    private MoveBehaviour _moveBehaviour;

    public SetMovementInputDisabledBoolean(Moment whenToRun, bool desiredValue)
    {
        _whenToRun = whenToRun;
        _desiredValue = desiredValue;
    }
    public override void Awake(StateMachine stateMachine)
    {
        _moveBehaviour = stateMachine.GetComponent<MoveBehaviour>();
    }

    public override void OnUpdate()
    {
        if (_whenToRun == SpecificMoment.OnUpdate)
            _moveBehaviour.MovementInputDisabled = _desiredValue;
    }

    public override void OnStateEnter()
    {
        if (_whenToRun == SpecificMoment.OnStateEnter)
        {
            _moveBehaviour.MovementInputDisabled = _desiredValue;
        }
    }

    public override void OnStateExit()
    {
        if (_whenToRun == SpecificMoment.OnStateExit)
        {
            _moveBehaviour.MovementInputDisabled = _desiredValue;
        }
    }
}
