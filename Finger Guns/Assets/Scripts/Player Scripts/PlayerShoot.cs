using UnityEngine;

public class PlayerShoot: Shoot
{
    #region Variables
    //Components and References
    private FgmInputHandler player;
    #endregion

    #region Monobehaviour Callbacks 

    private void Awake()
    {
        player = GetComponent<FgmInputHandler>();
        //playerAnim = GetComponent<>();
    }

    #endregion

    #region Overidden methods
    protected override void ShootProjectile()
    {
        base.ShootProjectile();
        GetComponent<Animator>().SetTrigger(FGMAnimHashes.PlayerShootingHash); //need to fix
    }
    #endregion
}