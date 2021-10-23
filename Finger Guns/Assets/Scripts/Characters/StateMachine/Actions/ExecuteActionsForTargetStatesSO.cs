using UnityEngine;
using System.Collections.Generic;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;
using Moment = FingerGuns.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "ExecuteActionsForTargetStates", menuName = "State Machines/Actions/Execute Actions For Target States")]
public class ExecuteActionsForTargetStatesSO : StateActionSO
{
    [Space]
    [SerializeField]
    public Moment whenToRun;
    [Space]
    [SerializeField]
    private List<StateActionSO> actionsToExecute;
    [SerializeField]
    private List<StateSO> targetStates;
    protected override StateAction CreateAction() => new ExecuteActionsForTargetStates(actionsToExecute, targetStates);
}

public class ExecuteActionsForTargetStates : StateAction
{
    private StateMachine _stateMachine;
    private List<StateActionSO> _actionsToExecute;
    private List<StateSO> _targetStates;
    private ExecuteActionsForTargetStatesSO _originSO => (ExecuteActionsForTargetStatesSO)base.OriginSO; // The SO this StateAction spawned from

    public ExecuteActionsForTargetStates(List<StateActionSO> actionsToExecute, List<StateSO> targetStates)
    {
        _actionsToExecute = actionsToExecute;
        _targetStates = targetStates;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public override void OnStateEnter()
    {
        if (_originSO.whenToRun == SpecificMoment.OnStateEnter)
        {
            foreach (var targetState in _targetStates)
            {
                if (targetState != null && _stateMachine.NextState != null && targetState.name.Equals(_stateMachine.NextState, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (var action in _actionsToExecute)
                        action.GetAction(_stateMachine, _stateMachine.GetCreatedInstances).OnStateEnter();
                }
            }
        }
    }
    public override void OnStateExit()
    {
        if (_originSO.whenToRun == SpecificMoment.OnStateExit)
        {
            foreach (var targetState in _targetStates)
            {
                if (targetState != null && _stateMachine.NextState != null && targetState.name.Equals(_stateMachine.NextState, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (var action in _actionsToExecute)
                        action.GetAction(_stateMachine, _stateMachine.GetCreatedInstances).OnStateExit();
                }
            }
        }
    }
    public override void OnUpdate() 
    {
        if (_originSO.whenToRun == SpecificMoment.OnUpdate)
        {
            foreach (var targetState in _targetStates)
            {
                if (targetState != null && _stateMachine.NextState != null && targetState.name.Equals(_stateMachine.NextState, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (var action in _actionsToExecute)
                        action.GetAction(_stateMachine, _stateMachine.GetCreatedInstances).OnUpdate();
                }
            }
        }
    }
}
