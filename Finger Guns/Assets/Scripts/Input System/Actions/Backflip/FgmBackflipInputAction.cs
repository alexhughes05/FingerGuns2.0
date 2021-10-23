using System;
using System.Collections;
using UnityEngine;

public class FgmBackflipInputAction : BackflipInputAction
{
    private readonly DetectEndOfFlip[] detectEndOfFlipInstances;
    private readonly JumpInputAction _jumpInputAction;
    private readonly float _maxBackflipThreshold = 0.05f;
    private MoveBehaviour _moveBehaviour;
    private float _backflipBufferCounter;
    private float _backFlipThresholdCounter;

    public FgmBackflipInputAction(GameObject go, BackflipData backflipData, JumpInputAction fgmJumpInputAction) : base(go, backflipData)
    {
        detectEndOfFlipInstances = go.GetComponent<Animator>().GetBehaviours<DetectEndOfFlip>();
        foreach (var detectEndOfFlipInstance in detectEndOfFlipInstances)
            detectEndOfFlipInstance.FlipAnimationEnded += () => PlayerCurrentlyFlipping = false;

        _jumpInputAction = fgmJumpInputAction;

        go.TryGetComponent(out _moveBehaviour);
        if (_moveBehaviour == null)
            throw new Exception("The MoveBehaviour component was required and could not be found.");
    }

    public override void PerformAction()
    {
        _backflipBufferCounter = Time.time + _backflipBufferInSeconds;
        _mono.StartCoroutine(HandleFgmBackflip());
    }

    public IEnumerator HandleFgmBackflip()
    {
        bool loop = true;
        while (loop)
        {
            _backFlipThresholdCounter += Time.deltaTime; //Increment timer used to determine if player should flip or jump. Needed because if player stops suddenly and jumps, they will flip instead.
            if (_backFlipThresholdCounter > _maxBackflipThreshold)
            {
                bool isFlipInsteadOfJump = true;//_moveBehaviour.CurrentlyMoving;
                if (isFlipInsteadOfJump && _backflipBufferCounter > Time.time && BackflipCoyoteCounter > 0) //If you held down long enough to register a flip, you are grounded, and you are within the flip buffer time and coyote time
                {
                    _anim.SetBool(FGMAnimHashes.PlayerBackflipHash, true);
                    _rb2d.velocity = _backflipForce;
                    PlayerCurrentlyFlipping = true;
                    loop = false;
                }
                else if (isFlipInsteadOfJump == false && _backflipBufferCounter > Time.time && BackflipCoyoteCounter > 0)
                {
                    loop = false;
                    _jumpInputAction.PerformAction();
                }
            }
            yield return null;
        }
    }
}
