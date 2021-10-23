using System;
using UnityEngine;

public abstract class RunInputAction : GenericInputAction
{
    protected readonly Rigidbody2D _rb2d;
    protected readonly GroundedChecker _groundChecker;
    protected readonly MoveBehaviour _moveBehaviour;
    public bool InputToggle { get; set; }
    public float MovementValue { get; set; }
    protected RunInputAction(GameObject go) : base(go)
    {
        go.TryGetComponent(out _rb2d);
        if (_rb2d == null)
            throw new Exception("Rigidbody2D component was required and could not be found.");
        go.TryGetComponent(out _groundChecker);
        if (_groundChecker == null)
            throw new Exception("The GroundChecker component was required and could not be found.");
        go.TryGetComponent(out _moveBehaviour);
        if (_moveBehaviour == null)
            throw new Exception("The MoveBehaviour component was required and could not be found.");
    }
}