using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region
    //Inspector
    [SerializeField]
    private float maxLifetime = 1f;

    //Components and References
    private Rigidbody2D rb2d;

    //private
    private float lifeTime;
    private Vector3 localScaleVector;

    //Properties
    public Vector2 Direction { get; set; }
    public float ProjectileSpeed { get; set; }

    #endregion

    #region Monobehaviour Callbacks

    private void Awake()
    {
        localScaleVector = transform.localScale;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        lifeTime = 0f;
        rb2d.velocity = Vector3.Normalize(Direction) * ProjectileSpeed;
    }
    private void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifetime) ShotPool.Instance.ReturnToPool(this);
    }
    #endregion
    public void FlipProjectileXAxis()
    {
        localScaleVector.x *= -1;
        transform.localScale = localScaleVector;
    }
}
