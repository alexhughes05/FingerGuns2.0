using System;
using UnityEngine;

public abstract class CrouchInputAction : GenericInputAction
{
    protected MoveBehaviour _moveBehaviour;
    public bool InputToggle { get; set; }
    public bool CurrentlyCrouching { get; set; }
    public bool CrouchKeyDown { get; set; }
    protected CrouchInputAction(GameObject go) : base(go)
    {
        go.TryGetComponent(out _moveBehaviour); //Should move to fgmCrouchInputAction
        if (_moveBehaviour == null)
            throw new Exception("The MoveBehaviour component was required and could not be found.");
    }
}