using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "FgmInputReader", menuName = "Gameplay/Input/FgmInput")]
public class FgmInputReader : ScriptableObject, PlayerControls.IFingerGunManActions
{
    #region Variables

    //Gameplay Events
    #region Gameplay Events
    public event UnityAction<float> JumpEvent = delegate { };
    public event UnityAction JumpCanceledEvent = delegate { };
    public event UnityAction<XDirections> StartMovingEvent = delegate { };
    public event UnityAction StopMovingEvent = delegate { };
    public event UnityAction CrouchEvent = delegate { };
    public event UnityAction CrouchCanceledEvent = delegate { };
    public event UnityAction<XDirections, float> SlideEvent = delegate {};
    public event UnityAction<XDirections, float> SlideCanceledEvent = delegate { };
    public event UnityAction<XDirections, float> FlipEvent = delegate { };
    public event UnityAction<XDirections> FlipCanceledEvent = delegate { };
    public event UnityAction ShootEvent = delegate { };
    public event UnityAction<Vector2> AimEvent = delegate { };
    #endregion

    //Properties
    public XDirections MovementDirection { get; private set; }
    public PlayerControls PlayerControls { get; private set; }

    #endregion

    private void OnEnable()
    {
        if (PlayerControls == null)
        {
            PlayerControls = new PlayerControls();
            PlayerControls.FingerGunMan.SetCallbacks(this);
        }
        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    public void OnMoveHorizontal(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            StartMovingEvent.Invoke((PlayerControls.FingerGunMan.MoveHorizontal.ReadValue<float>() > 0) ? XDirections.Right : XDirections.Left);
        }

        if (context.phase == InputActionPhase.Canceled)
            StopMovingEvent.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            JumpEvent.Invoke(Time.time);

        if (context.phase == InputActionPhase.Canceled)
            JumpCanceledEvent.Invoke();  
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            CrouchEvent.Invoke();

        if (context.phase == InputActionPhase.Canceled)
            CrouchCanceledEvent.Invoke();
    }

    public void OnSlideLeft(InputAction.CallbackContext context)
    {      
        if (context.phase == InputActionPhase.Performed)
            SlideEvent.Invoke(XDirections.Left, Time.time);

        if (context.phase == InputActionPhase.Canceled)
            SlideCanceledEvent.Invoke(XDirections.Left, Time.time);
    }

    public void OnSlideRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            SlideEvent.Invoke(XDirections.Right, Time.time);

        if (context.phase == InputActionPhase.Canceled)
            SlideCanceledEvent.Invoke(XDirections.Right, Time.time);
    }

    public void OnFlipLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            FlipEvent.Invoke(XDirections.Left, Time.time);

        if (context.phase == InputActionPhase.Canceled)
            FlipCanceledEvent.Invoke(XDirections.Left);
    }

    public void OnFlipRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            FlipEvent.Invoke(XDirections.Right, Time.time);

        if (context.phase == InputActionPhase.Canceled)
            FlipCanceledEvent.Invoke(XDirections.Right);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            ShootEvent.Invoke();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            AimEvent.Invoke(PlayerControls.FingerGunMan.Aim.ReadValue<Vector2>());
    }
}
