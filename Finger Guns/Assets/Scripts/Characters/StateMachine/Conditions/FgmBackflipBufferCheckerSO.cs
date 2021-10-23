using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "FgmBackflipBufferChecker", menuName = "State Machines/Conditions/Fgm Backflip Buffer Checker")]
public class FgmBackflipBufferCheckerSO : StateConditionSO
{
    [SerializeField]
    private float backflipBufferWindow;
    protected override Condition CreateCondition() => new FgmBackflipBufferChecker(backflipBufferWindow);
}

public class FgmBackflipBufferChecker : Condition
{
    private readonly float _backflipBufferWindow;
    private bool _hadBackflipInputWhenGrounded;
    private FgmInputHandler _fgmInputHandler;
    public FgmBackflipBufferChecker(float backflipBufferWindow)
    {
        _backflipBufferWindow = backflipBufferWindow;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _fgmInputHandler = stateMachine.GetComponent<FgmInputHandler>();
    }

    protected override bool Statement()
    {
        if (_hadBackflipInputWhenGrounded)
            return true;

        var finalBufferTime = _fgmInputHandler.BackflipTimeStamp + _backflipBufferWindow;
        if (Time.time < finalBufferTime)
        {
            _hadBackflipInputWhenGrounded = true;
            return true;
        }
        else
            return false;
    }

    public override void OnStateEnter()
    {
        _hadBackflipInputWhenGrounded = false;
    }

    public override void OnStateExit()
    {
        _hadBackflipInputWhenGrounded = false;
    }
}
