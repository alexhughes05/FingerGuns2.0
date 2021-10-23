using System;
using UnityEngine;

public class FgmRunInputAction : RunInputAction
{
    private readonly SomersaultInputAction _somersaultInputAction;
    private readonly BackflipInputAction _backflipInputAction;
    public FgmRunInputAction(GameObject go, SomersaultInputAction somersaultAction, BackflipInputAction backflipInputAction) : base(go)
    {
        _somersaultInputAction = somersaultAction;
        _backflipInputAction = backflipInputAction;
    }

    public override void PerformAction()
    {
        //_moveBehaviour.MoveInXDirection(MovementValue);
        if (InputToggle && _somersaultInputAction.PlayerCurrentlyFlipping == false && _backflipInputAction.PlayerCurrentlyFlipping == false && _groundChecker.Grounded)
            _anim.SetFloat(FGMAnimHashes.PlayerWalkHash, Math.Abs(MovementValue));
        else
            _anim.SetFloat(FGMAnimHashes.PlayerWalkHash, Math.Abs(MovementValue));
    }
}
