using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "SetCurrentMaxSpeedAction", menuName = "State Machines/Actions/Set Current Max Speed")]
public class SetCurrentMaxSpeedSO : StateActionSO
{
    [SerializeField]
    bool additiveToCurrentMaxSpeed;
    [Min(0)]
    [SerializeField]
    private float maxSpeed;
    protected override StateAction CreateAction() => new SetCurrentMaxSpeed(maxSpeed, additiveToCurrentMaxSpeed);
}

public class SetCurrentMaxSpeed : StateAction
{
    private MoveBehaviour _moveBehaviour;
    private readonly bool _additiveToCurrentMaxSpeed;
    private readonly float _maxSpeed;

    public SetCurrentMaxSpeed(float maxSpeed, bool relativeToCurrentMaxSpeed)
    {
        _additiveToCurrentMaxSpeed = relativeToCurrentMaxSpeed;
        _maxSpeed = maxSpeed;
    }
    public override void Awake(StateMachine stateMachine)
    {
        _moveBehaviour = stateMachine.GetComponent<MoveBehaviour>();
    }
    public override void OnStateEnter()
    {
        if (_additiveToCurrentMaxSpeed)
            _moveBehaviour.CurrentMaxSpeed += _maxSpeed;
        else
            _moveBehaviour.CurrentMaxSpeed = _maxSpeed;
        _moveBehaviour.ApplyMovement();
    }

    public override void OnUpdate() { }
}
