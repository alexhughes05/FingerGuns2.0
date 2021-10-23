//using System;
//using System.Collections;
//using UnityEngine;

//public class FgmSomersaultInputAction : SomersaultInputAction
//{
//    private readonly DetectEndOfFlip[] detectEndOfFlipInstances;
//    private readonly JumpInputAction _jumpInputAction;
//    private readonly MoveBehaviour _moveBehaviour;
//    private readonly float _maxSomersaultThreshold = 0.05f;
//    private float _somersaultBufferCounter;
//    private float _somersaultThresholdCounter;

//    public FgmSomersaultInputAction(GameObject go, SomersaultData somersaultData, JumpInputAction fgmJumpInputAction) : base(go, somersaultData)
//    {
//        detectEndOfFlipInstances = go.GetComponent<Animator>().GetBehaviours<DetectEndOfFlip>();
//        Debug.Log("The number of flip instances is " + detectEndOfFlipInstances.Length);
//        foreach (var detectEndOfFlipInstance in detectEndOfFlipInstances)
//            detectEndOfFlipInstance.FlipAnimationEnded += () => PlayerCurrentlyFlipping = false;

//        _jumpInputAction = fgmJumpInputAction;

//        go.TryGetComponent(out _moveBehaviour);
//        if (_moveBehaviour == null)
//            throw new Exception("The MoveBehaviour component was required and could not be found.");
//    }

//    public override void PerformAction()
//    {
//        _somersaultBufferCounter = Time.time + _somersaultBufferInSeconds;
//        _mono.StartCoroutine(HandleFgmSomersault());
//    }

//    public IEnumerator HandleFgmSomersault()
//    {
//        bool loop = true;
//        while (loop)
//        {
//            _somersaultThresholdCounter += Time.deltaTime; //Increment timer used to determine if player should flip or jump. Needed because if player stops suddenly and jumps, they will flip instead.
//            if (_somersaultThresholdCounter > _maxSomersaultThreshold)
//            {
//                bool isFlipInsteadOfJump = _moveBehaviour.CurrentlyMoving;
//                if (isFlipInsteadOfJump && _somersaultBufferCounter > Time.time && SomersaultCoyoteCounter > 0) //If you held down long enough to register a flip and you are within the flip buffer time and coyote time
//                {
//                    _anim.SetBool(FGMAnimHashes.PlayerSomersaultHash, true);
//                    _rb2d.velocity = _somersaultForce;
//                    PlayerCurrentlyFlipping = true;
//                    loop = false;
//                }
//                else if (_somersaultBufferCounter > Time.time && SomersaultCoyoteCounter > 0)
//                {
//                    loop = false;
//                    _jumpInputAction.PerformAction();
//                }
//            }
//            yield return null;
//        }
//    }
//}
