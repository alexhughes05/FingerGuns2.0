using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shoot : MonoBehaviour, IAttack
{
    //Inspector
    [Header("Firepoint")]
    [SerializeField]
    private Transform firePoint;
    [Space()]
    [Header("Firerate")]
    [SerializeField]
    private float fireRate = 0.5f;
    [Space()]
    [Header("Shooter")]
    [SerializeField]
    private float muzzleVelocity;
    [Header("SFX")]
    [SerializeField]
    [EventRef]
    public string shootRegularSound;
    private FMOD.Studio.EventInstance instance;

    //Private Fields
    private float timeOfLastShot;

    //Properties
    public float TimeOfCurrentShot { get; set; }
    public Vector3 TargetDirection { get; private set; }


    #region Public Methods
    public void TryToShoot(Vector3 targetPos)
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
        Debug.Log("executed. Gameobject is currently " + gameObject);
        Projectile shot = ShotPool.Instance.Get();
        shot.Direction = TargetDirection;
        shot.ProjectileSpeed = muzzleVelocity;
        shot.gameObject.SetActive(true);
        shot.transform.position = firePoint.transform.position;
        shot.transform.rotation = firePoint.transform.rotation;

        //SFX
        if (!string.IsNullOrEmpty(shootRegularSound))
        {
            Debug.Log("The value of shoot regular sound is " + shootRegularSound);
            instance = RuntimeManager.CreateInstance(shootRegularSound);
            instance.start();
            instance.release();
        }
    }

    //Interface implementations

    public void Attack(Vector3 target)
    {
        TimeOfCurrentShot = Time.time;
        TryToShoot(target);
    }
}
