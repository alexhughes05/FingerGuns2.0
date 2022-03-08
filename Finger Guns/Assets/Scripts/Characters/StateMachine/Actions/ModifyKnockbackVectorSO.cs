using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;
using System;

[CreateAssetMenu(fileName = "ModifyKnockbackVector", menuName = "State Machines/Actions/Modify Knockback Vector")]
public class ModifyKnockbackVectorSO : StateActionSO
{
    [Space] [SerializeField] private Moment whenToRun;
    [Space] [SerializeField] private Axis knockbackComponent;
    [Space] [SerializeField] private float desiredValue;
    [Space] [SerializeField] private bool applyWhenGrounded;

    protected override StateAction CreateAction() => new ModifyKnockbackVector(whenToRun, knockbackComponent, desiredValue, applyWhenGrounded);
}

public class ModifyKnockbackVector : StateAction
{
    private readonly Moment _whenToRun;
    private readonly Axis _knockbackComponent;
    private readonly float _desiredValue;
    private readonly bool _applyWhenGrounded;

    private Knockbackable _knockbackable;
    private GroundedChecker _groundChecker;

    public ModifyKnockbackVector(Moment whenToRun, Axis knockbackComponent, float desiredValue, bool applyWhenGrounded)
    {
        _knockbackComponent = knockbackComponent;
        _desiredValue = desiredValue;
        _applyWhenGrounded = applyWhenGrounded;
    }

    public override void Awake(StateMachine stateMachine)
    {
        stateMachine.TryGetComponent(out _knockbackable);
        if (_knockbackable == null)
            Debug.LogError("AddKnockbackForceSO was unable to find the Knockbackable component on gameobject " + stateMachine.gameObject.name);
        if (_applyWhenGrounded)
        {
            stateMachine.TryGetComponent(out _groundChecker);
            if (_groundChecker == null)
                Debug.LogError("AddKnockbackForceSO was unable to find the GroundChecker component on gameobject " + stateMachine.gameObject.name);
        }
    }

    public override void OnUpdate()
    {
        SetKnockbackVector(Moment.OnUpdate);
    }

    public override void OnStateEnter()
    {
        SetKnockbackVector(Moment.OnStateEnter);
    }

    public override void OnStateExit()
    {
        SetKnockbackVector(Moment.OnStateExit);
    }
    private void SetKnockbackVector(Moment specifiedMoment)
    {
        if (specifiedMoment == _whenToRun)
        {
            switch(_knockbackComponent)
            {
                case Axis.X:
                        if (_applyWhenGrounded && _groundChecker.Grounded || !_applyWhenGrounded)
                            _knockbackable.KnockbackVector = new Vector2(_desiredValue, _knockbackable.KnockbackVector.y);
                    break;
                case Axis.Y:
                    if (_applyWhenGrounded && _groundChecker.Grounded || !_applyWhenGrounded)
                        _knockbackable.KnockbackVector = new Vector2(_knockbackable.KnockbackVector.x, _desiredValue);
                    break;
                case Axis.XY:
                    if (_applyWhenGrounded && _groundChecker.Grounded || !_applyWhenGrounded)
                        _knockbackable.KnockbackVector = new Vector2(_desiredValue, _desiredValue);
                    break;
            }
        }
    }
}
