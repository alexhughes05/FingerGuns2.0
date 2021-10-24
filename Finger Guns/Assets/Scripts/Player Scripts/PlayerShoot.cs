using UnityEngine;

public class PlayerShoot: Shoot
{

    #region Variables
    private PlayerAim _playerAim;
    #endregion

    #region Monobehaviour Callbacks 

    private void Awake()
    {
        _playerAim = GetComponent<PlayerAim>();
    }

    #endregion

    #region Overidden methods
    protected override void ShootProjectile()
    {
        TargetDirection = _playerAim.AimDirection;
        base.ShootProjectile();
        GetComponent<Animator>().SetTrigger(FGMAnimHashes.PlayerShootingHash);
    }
    #endregion
}