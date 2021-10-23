using System;
using UnityEngine;

public abstract class GenericInputAction
{
    protected readonly Animator _anim;
    protected GenericInputAction(GameObject go)
    {
        go.TryGetComponent(out _anim);
        if (_anim == null)
            throw new Exception("The Animator component was required and could not be found.");
    }

    public abstract void PerformAction();
}
