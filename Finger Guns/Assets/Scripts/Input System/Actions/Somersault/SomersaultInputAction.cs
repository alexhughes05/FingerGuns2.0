using System;
using UnityEngine;
public abstract class SomersaultInputAction : GenericInputAction
{
    protected readonly MonoBehaviour _mono;
    protected readonly Rigidbody2D _rb2d;
    protected Vector2 _somersaultForce;
    protected float _somersaultBufferInSeconds;
    public bool PlayerCurrentlyFlipping { get; set; }
    public float SomersaultCoyoteCounter { get; set; }
    public float SomersaultCoyoteTimeInSeconds { get; private set; }

    protected SomersaultInputAction(GameObject go, SomersaultData somersaultData) : base(go)
    {
        go.TryGetComponent(out _mono);
        if (_mono == null)
            throw new Exception("MonoBehaviour component was required and could not be found.");
        go.TryGetComponent(out _rb2d);
        if (_rb2d == null)
            throw new Exception("Rigidbody2D component was required and could not be found.");
        _somersaultForce = somersaultData.SomersaultForce;
        _somersaultBufferInSeconds = somersaultData.SomersaultBufferInSeconds;
        SomersaultCoyoteTimeInSeconds = somersaultData.CoyoteTimeInSeconds;
    }
}