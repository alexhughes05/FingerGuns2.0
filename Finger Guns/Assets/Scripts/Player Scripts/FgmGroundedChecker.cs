//using UnityEngine;

//public class FgmGroundedChecker : GroundedChecker
//{
//    //References
//    private SomersaultInputAction _somersaultInputAction;
//    private BackflipInputAction _backflipInputAction;

//    //Fields
//    private bool _coyoteCountersNotYetReset;

//    //protected override void Update()
//    {
//        //if (_somersaultInputAction.PlayerCurrentlyFlipping || _backflipInputAction.PlayerCurrentlyFlipping)
//            //SetGroundedToFalse();
//        //else
//        //{
//            base.Update();
//            UpdateCoyoteCounters();
//       // }
//    }
//    public void InitializeFlips(SomersaultInputAction somersaultInputAction, BackflipInputAction backflipInputAction)
//    {
//        _backflipInputAction = backflipInputAction;
//        _somersaultInputAction = somersaultInputAction;
//    }
//    private void ResetCoyoteCounters()
//    {
//        _coyoteCountersNotYetReset = false;
//        _somersaultInputAction.SomersaultCoyoteCounter = 0;
//        _backflipInputAction.BackflipCoyoteCounter = 0;
//    }
//    private void SetGroundedToFalse()
//    {
//        if (_coyoteCountersNotYetReset)
//            ResetCoyoteCounters();

//        if (Grounded)
//        {
//            Grounded = false;
//            WasGrounded = !Grounded;
//        }

//        DrawUpdatedRay(Color.red);
//    }
//    private void UpdateCoyoteCounters()
//    {
//        _coyoteCountersNotYetReset = true;

//        if (Grounded)
//        {
//            _somersaultInputAction.SomersaultCoyoteCounter = _somersaultInputAction.SomersaultCoyoteTimeInSeconds;
//            _backflipInputAction.BackflipCoyoteCounter = _backflipInputAction.BackflipCoyoteTimeInSeconds;
//        }
//        else
//        {
//            _somersaultInputAction.SomersaultCoyoteCounter -= Time.deltaTime;
//            _backflipInputAction.BackflipCoyoteCounter -= Time.deltaTime;
//        }
//    }
//}
