using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
public class FgmInputHandler : MonoBehaviour
{
    //Inspector
    [SerializeField]
    private FgmInputReader _inputReader;

    //References
    private DirectionBehaviour _directionBehaviour;
    private FgmSlideTimers _fgmSlideTimers;

    //Instance fields
    private bool _endOfJumpCriticalSection;
    private bool _endOfLandingCriticalSection;
    private bool _endOfBackflipCriticalSection;
    private bool _endOfSomersaultCriticalSection;

    private XDirections _moveDirection;

    //Properties
    public bool JumpInput { get; set; }
    public bool SlideInput { get; set; }
    public bool MovingInput { get; private set; }
    public bool CrouchInput { get; private set; }
    public bool SomersaultInput { get; set; }
    public bool BackflipInput { get; set; }
    public float JumpTimeStamp { get; set; } = Mathf.NegativeInfinity;
    public float SlideTimeStamp { get; set; } = Mathf.NegativeInfinity;
    public float SomersaultTimeStamp { get; set; } = Mathf.NegativeInfinity;
    public float BackflipTimeStamp { get; set; } = Mathf.NegativeInfinity;

    private void Awake()
    {
        TryGetComponent<DirectionBehaviour>(out _directionBehaviour);
        if (_directionBehaviour == null)
            Debug.LogError("The Direction Behaviour component cannot be found.");

        TryGetComponent<FgmSlideTimers>(out _fgmSlideTimers);
        if (_fgmSlideTimers == null)
            Debug.LogError("The FgmSlideTimers component cannot be found.");
    }


    private void OnEnable()
    {
        _inputReader.StartMovingEvent += OnStartMovingInitiated;
        _inputReader.StopMovingEvent += OnStopMovingInitiated;
        _inputReader.JumpEvent += OnJumpInitiated;
        _inputReader.JumpCanceledEvent += OnJumpCanceled;
        _inputReader.CrouchEvent += OnCrouchInitiated;
        _inputReader.CrouchCanceledEvent += OnCrouchCanceled;
        _inputReader.SlideEvent += OnSlideInitiated;
        _inputReader.FlipEvent += OnFlip;
        _inputReader.FlipCanceledEvent += OnFlipCanceled;
    }

    private void OnDisable()
    {
        _inputReader.StartMovingEvent -= OnStartMovingInitiated;
        _inputReader.StopMovingEvent -= OnStopMovingInitiated;
        _inputReader.JumpEvent -= OnJumpInitiated;
        _inputReader.JumpCanceledEvent -= OnJumpCanceled;
        _inputReader.CrouchEvent -= OnCrouchInitiated;
        _inputReader.CrouchCanceledEvent -= OnCrouchCanceled;
        _inputReader.SlideEvent -= OnSlideInitiated;
        _inputReader.FlipEvent -= OnFlip;
        _inputReader.FlipCanceledEvent -= OnFlipCanceled;
    }

    private void Update()
    {
        //OnJumpInitiated(Time.time);
        //Debug.Log("LANDING IS CURRENTLY " + IsLandingAnimFinished());
    }

    private void OnStartMovingInitiated(XDirections moveDirection)
    {
        _moveDirection = moveDirection;
        MovingInput = true;
    }
    private void OnStopMovingInitiated()
    {
        _moveDirection = XDirections.None;
        MovingInput = false;
    }
    private void OnFlip(XDirections flipDirection, float startingFlipTime)
    {
        if (_directionBehaviour.FacingDirection == flipDirection)
        {
            SomersaultInput = true;
            SomersaultTimeStamp = startingFlipTime;
        }
        else
        {
            BackflipInput = true;
            BackflipTimeStamp = startingFlipTime;
        }
    }
    private void OnFlipCanceled(XDirections flipDirection)
    {
        if (_directionBehaviour.FacingDirection == flipDirection)
            SomersaultInput = false;
        else
            BackflipInput = false;
    }
    private void OnSlideInitiated(XDirections slideDirection, float slideStartingTime)
    {
        if (_directionBehaviour.FacingDirection == slideDirection && CrouchInput == false && slideStartingTime >= _fgmSlideTimers.TimeWhenCanSlideAgain)
        {
            SlideInput = true;
            CrouchInput = true;
            SlideTimeStamp = slideStartingTime;
        }
    }

    private void OnCrouchInitiated()
    {
        if ((MovingInput && _directionBehaviour.FacingDirection != _moveDirection) || MovingInput == false)
            CrouchInput = true;
    }
    private void OnCrouchCanceled()
    {
        CrouchInput = false;
    }
    private void OnJumpInitiated(float jumpStartingTime)
    {
        JumpInput = true;
        JumpTimeStamp = jumpStartingTime;     
    }
    private void OnJumpCanceled()
    {
        JumpInput = false;
    }

    #region Critical Section methods
    public bool IsLandingCriticalSectionDone() => _endOfLandingCriticalSection;
    public bool IsJumpCriticalSectionDone() => _endOfJumpCriticalSection;
    public bool IsBackflipAnimDone() => _endOfBackflipCriticalSection;
    public bool IsSomersaultAnimDone() => _endOfSomersaultCriticalSection;
    public void SetEndOfJumpCriticalSection(int value) => _endOfJumpCriticalSection = Convert.ToBoolean(value);
    public void SetEndOfLandingCriticalSection(int value) => _endOfLandingCriticalSection = Convert.ToBoolean(value);
    public void SetEndOfBackflipAnim(int value) => _endOfBackflipCriticalSection = Convert.ToBoolean(value);
    public void SetEndOfSomersaultAnim(int value) => _endOfSomersaultCriticalSection = Convert.ToBoolean(value);
    #endregion
}


