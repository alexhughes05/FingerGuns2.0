using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "FgmSomersaultBufferChecker", menuName = "State Machines/Conditions/Fgm Somersault Buffer Checker")]
public class FgmSomersaultBufferCheckerSO : StateConditionSO
{
    [SerializeField]
    private float somersaultBufferWindow;
    protected override Condition CreateCondition() => new FgmSomersaultBufferChecker(somersaultBufferWindow);
}

public class FgmSomersaultBufferChecker : Condition
{
    private readonly float _somersaultBufferWindow;
    private bool _hadSomersaultInputWhenGrounded;
    private FgmInputHandler _fgmInputHandler;
    public FgmSomersaultBufferChecker(float somersaultBufferWindow)
    {
        _somersaultBufferWindow = somersaultBufferWindow;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _fgmInputHandler = stateMachine.GetComponent<FgmInputHandler>();
    }

    protected override bool Statement()
    {
        if (_hadSomersaultInputWhenGrounded)
            return true;

        var finalBufferTime = _fgmInputHandler.SomersaultTimeStamp + _somersaultBufferWindow;
        if (Time.time < finalBufferTime)
        {
            _hadSomersaultInputWhenGrounded = true;
            return true;
        }
        else
            return false;
    }

    public override void OnStateEnter()
    {
        _hadSomersaultInputWhenGrounded = false;
    }

    public override void OnStateExit()
    {
        _hadSomersaultInputWhenGrounded = false;
    }
}

