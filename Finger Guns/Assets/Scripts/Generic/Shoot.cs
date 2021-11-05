using FMODUnity;
using UnityEngine;

public class Shoot : MonoBehaviour, IAttack
{
    //Inspector
    [SerializeField]
    GameObjectPool shotPool;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private float muzzleVelocity;
    [Header("SFX")]
    [EventRef]
    public string shootRegularSound;
    private FMOD.Studio.EventInstance instance;

    //Private Fields
    private float timeOfLastShot;

    //Properties
    public float TimeOfCurrentShot { get; set; }
    public Vector3 TargetDirection { get; protected set; }

    #region Public Methods
    private void TryToShoot(Vector3 targetPos)
    {
        if (TimeOfCurrentShot - timeOfLastShot >= fireRate)
        {
            TargetDirection = Vector3.Normalize(targetPos - firePoint.position);
            ShootProjectile();
            timeOfLastShot = TimeOfCurrentShot;
        }
    }
    #endregion

    protected virtual void ShootProjectile()
    {
        Projectile shot = shotPool.Get().GetComponent<Projectile>();
        shot.AssociatedPool = shotPool;
        if (TargetDirection.x < 0 && shot.transform.localScale.x > 0 || TargetDirection.x > 0 && shot.transform.localScale.x < 0)
            shot.FlipProjectileXAxis();
        shot.Direction = TargetDirection;
        shot.ProjectileSpeed = muzzleVelocity;
        shot.transform.position = firePoint.transform.position;
        shot.transform.rotation = firePoint.transform.rotation;
        shot.gameObject.SetActive(true);

        //SFX
        if (!string.IsNullOrEmpty(shootRegularSound))
        {
            instance = RuntimeManager.CreateInstance(shootRegularSound);
            instance.start();
            instance.release();
        }
    }
    //Setting Animation Parameter

    //Interface implementations
    public void Attack(Vector3 target)
    {
        TimeOfCurrentShot = Time.time;
        TryToShoot(target);
    }
}
