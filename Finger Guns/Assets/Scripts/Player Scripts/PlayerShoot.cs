using UnityEngine;

public class PlayerShoot: Shoot
{

    #region Variables
    private PlayerAim _playerAim;
    private Animator _anim;
    private Health _health;
    #endregion

    #region Monobehaviour Callbacks 

    private void Awake()
    {
        TryGetComponent(out _anim);
        if (_anim == null)
            Debug.LogError("The Animator component could not be found on the game object " + gameObject.name);

        TryGetComponent(out _playerAim);
        if (_playerAim == null)
            Debug.LogError("The PlayerAim component could not be found on the game object " + gameObject.name);

        TryGetComponent(out _health);
        if (_health == null)
            Debug.LogError("The Health component could not be found on the game object " + gameObject.name);
    }

    #endregion

    #region Overidden methods
    protected override void ShootProjectile()
    {
        if (_health.CurrentHealth > 0)
        {
            TargetDirection = _playerAim.AimDirection;
            base.ShootProjectile();
            _anim.SetTrigger(FGMAnimHashes.PlayerShootingHash);
        }
    }
    #endregion
}