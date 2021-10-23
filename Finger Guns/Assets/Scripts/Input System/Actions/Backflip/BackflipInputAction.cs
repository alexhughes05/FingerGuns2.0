using System;
using UnityEngine;
public abstract class BackflipInputAction : GenericInputAction
{
    protected readonly MonoBehaviour _mono;
    protected readonly Rigidbody2D _rb2d;
    protected Vector2 _backflipForce;
    protected float _backflipBufferInSeconds;
    public bool PlayerCurrentlyFlipping { get; set; }
    public float BackflipCoyoteCounter { get; set; }
    public float BackflipCoyoteTimeInSeconds { get; private set; }

    protected BackflipInputAction(GameObject go, BackflipData backflipData) : base(go)
    {
        go.TryGetComponent(out _mono);
        if (_mono == null)
            throw new Exception("MonoBehaviour component was required and could not be found.");
        go.TryGetComponent(out _rb2d);
        if (_rb2d == null)
            throw new Exception("Rigidbody2D component was required and could not be found.");
        _backflipForce = backflipData.BackflipForce;
        _backflipBufferInSeconds = backflipData.BackflipBufferInSeconds;
        BackflipCoyoteTimeInSeconds = backflipData.CoyoteTimeInSeconds;
    }
}