using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FGMAnimHashes
{
    //Animation Hashes
    #region AnimationHashes
    public static int PlayerWalkHash { get; } = Animator.StringToHash("Walking");
    public static int PlayerJumpHash { get; } = Animator.StringToHash("Jump");
    public static int PlayerBackflipHash { get; } = Animator.StringToHash("Backflip");
    public static int PlayerShootingHash { get; } = Animator.StringToHash("Shoot");
    public static int PlayerFallingHash { get; } = Animator.StringToHash("Falling");
    public static int PlayerAFKHash { get; } = Animator.StringToHash("AFK");
    public static int PlayerLandingHash { get; } = Animator.StringToHash("Landing");
    public static int PlayerSlideHash { get; } = Animator.StringToHash("Slide");
    public static int PlayerSomersaultHash { get; } = Animator.StringToHash("Somersault");
    public static int PlayerDeathHash { get; } = Animator.StringToHash("Death");
    public static int PlayerTakeDamageHash { get; } = Animator.StringToHash("Take Damage");
    public static int PlayerTakeDamageElectricHash { get; } = Animator.StringToHash("Take Damage Electric");
    public static int PlayerCrouchHash { get; } = Animator.StringToHash("Crouch");
    public static int PlayerFallBackHash { get; } = Animator.StringToHash("Fall Back");
    public static int PlayerStandUpHash { get; } = Animator.StringToHash("Stand Up");
    public static int PlayerFallForwardHash { get; } = Animator.StringToHash("Fall Forward");
    public static int PlayerStandUpForwardHash { get; } = Animator.StringToHash("StandUp_Forward");

    #endregion
}
