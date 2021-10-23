using System;
using UnityEngine;

public abstract class JumpInputAction : GenericInputAction
{
    protected readonly MonoBehaviour _mono;
    protected readonly Rigidbody2D _rb2d;
    protected readonly GroundedChecker _groundChecker;
    protected float _jumpForce;
    protected float _jumpBufferInSeconds;
    protected JumpInputAction(GameObject go, JumpData jumpData) : base(go)
    {
        
        go.TryGetComponent(out _mono);
        if (_mono == null)
            throw new Exception("MonoBehaviour component was required and could not be found.");
        go.TryGetComponent(out _rb2d);
        if (_rb2d == null)
            throw new Exception("Rigidbody2D component was required and could not be found.");
        go.TryGetComponent(out _groundChecker);
        if (_groundChecker == null)
            throw new Exception("The GroundChecker component was required and could not be found."); //Move to fgmJumpInputAction
        _jumpForce = jumpData.JumpForce;
        _jumpBufferInSeconds = jumpData.JumpBufferInSeeconds;
    }
}
