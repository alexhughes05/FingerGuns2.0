//using System.Collections;
//using UnityEngine;

//public class FgmSlideInputAction : SlideInputAction
//{
//    private bool _waitingToSlideAgain;
//    private float _slideBufferCounter;
//    private readonly CrouchInputAction _crouchInputAction;
//    public FgmSlideInputAction(GameObject go, SlideData slideData, CrouchInputAction crouchInputAction) : base(go, slideData)
//    {
//        _crouchInputAction = crouchInputAction;
//    }

//    public override void PerformAction()
//    {
//        _slideBufferCounter = Time.time + _slideBufferInSeconds;
//        _mono.StartCoroutine(HandleSliding(SlidingRight));
//    }

//    public IEnumerator HandleSliding(bool slidingRight)
//    {
//        bool loop = true;
//        while (loop)
//        {
//            if (_slideBufferCounter > Time.time) //If you are within the slide buffer time
//            {
//                if (_groundChecker.Grounded && _waitingToSlideAgain == false) //time delay after your last slide has already expired
//                {
//                    loop = false;
//                    PlayerCurrentlySliding = true;
//                    _waitingToSlideAgain = true;
//                    _anim.SetBool(FGMAnimHashes.PlayerSlideHash, true);
//                    _moveBehaviour.MovementInputDisabled = true; //Might need some type of system so if one force disables movement, another can't enable it when the other is still going.
//                    if (slidingRight)
//                        _rb2d.velocity = new Vector2(_moveBehaviour.CurrentMaxSpeed + _addedSlideSpeed, 0);
//                    else
//                        _rb2d.velocity = new Vector2(-_moveBehaviour.CurrentMaxSpeed - _addedSlideSpeed, 0);
//                    _mono.StartCoroutine(WaitAndStopSliding());
//                }
//            }
//            yield return null;
//        }
//    }

//    private IEnumerator WaitAndStopSliding()
//    {
//        yield return new WaitForSeconds(_maxSlideTime);
//        PlayerCurrentlySliding = false;
//        if (_crouchInputAction.CrouchKeyDown)
//        {
//            _crouchInputAction.InputToggle = true;
//            _crouchInputAction.PerformAction(); //If you are sliding and then release the 'a' or 'd' key you will only be pressing 's' so you should crouch immediately after the slide
//        }                                       //However since 'a' + 's' or 'd' + 's' is registered as slide, without explicitly setting crouch back to true it will remain false
//        if (_moveBehaviour.CurrentlyMoving == false)
//            _moveBehaviour.StopXMovement();
        
//        _anim.SetBool(FGMAnimHashes.PlayerSlideHash, false);
//        _moveBehaviour.MovementInputDisabled = false;
//        yield return new WaitForSeconds(_timeBtwSlides);
//        _waitingToSlideAgain = false;
//    }
//}
