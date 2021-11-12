using UnityEngine;

public class PlayerShoot: Shoot
{

    #region Variables
    private PlayerAim _playerAim;
    private Animator _anim;
    #endregion

    #region Monobehaviour Callbacks 

    private void Awake()
    {
        _playerAim = GetComponent<PlayerAim>();
        _anim = GetComponent<Animator>();
    }

    #endregion

    #region Overidden methods
    protected override void ShootProjectile()
    {
        TargetDirection = _playerAim.AimDirection;
        base.ShootProjectile();
        _anim.SetTrigger(FGMAnimHashes.PlayerShootingHash);
    }
    #endregion
}