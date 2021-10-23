using System.Collections;
using UnityEngine;

public class FgmJumpInputAction : JumpInputAction
{
    private readonly CrouchInputAction _fgmCrouchInputAction;
    private float _jumpCounter;


    public FgmJumpInputAction(GameObject go, JumpData jumpData, CrouchInputAction fgmCrouchInputAction) : base(go, jumpData)
    {
        _fgmCrouchInputAction = fgmCrouchInputAction;
    }

    public override void PerformAction()
    {
        _jumpCounter = Time.time + _jumpBufferInSeconds;
        _mono.StartCoroutine(HandleJumping());
    }

    public IEnumerator HandleJumping()
    {
        bool loop = true;
        while (loop)
        {
            if (_groundChecker.Grounded && _jumpCounter >= Time.time)
            {
                //_jumpCounter = 0;
                if (_fgmCrouchInputAction.CurrentlyCrouching == false) _anim.SetBool(FGMAnimHashes.PlayerJumpHash, true); //To allow crouch jumping without getting stuck in the animation.
                _rb2d.velocity = Vector2.zero;
                _rb2d.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
                loop = false;
            }
            yield return null;
        }
    }
}
