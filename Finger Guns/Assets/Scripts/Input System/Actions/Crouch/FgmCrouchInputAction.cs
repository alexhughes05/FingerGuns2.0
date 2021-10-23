//using UnityEngine;

//public class FgmCrouchInputAction : CrouchInputAction
//{
//    public FgmCrouchInputAction(GameObject go) : base(go) { }
    
//    public override void PerformAction()
//    {
//        Debug.Log("executed crouch perform action. InputToggle is " + InputToggle);
//        Debug.Log("CurrentlyCrouching is " + CurrentlyCrouching);
//        _anim.SetBool(FGMAnimHashes.PlayerCrouchHash, InputToggle);
//        if (InputToggle)
//        {
//            if (CurrentlyCrouching == false) //Only want the speed to be reduced one time, when you first crouch
//            {
//                _moveBehaviour.UpdateCurrentMaxSpeed(newMaxSpeed: _moveBehaviour.CurrentMaxSpeed / 2); //Move half your normal speed
//                CurrentlyCrouching = true;
//            }
//        }
//        else if (CurrentlyCrouching)
//        {
//            _moveBehaviour.UpdateCurrentMaxSpeed(newMaxSpeed: _moveBehaviour.CurrentMaxSpeed * 2); //Move half your normal speed //Reset back to original speed
//            CurrentlyCrouching = false;
//        }
//    }
//}
