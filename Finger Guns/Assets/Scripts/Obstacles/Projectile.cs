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
    private bool alreadyCollided;

    //Properties
    public Vector2 Direction { get; set; }
    public float ProjectileSpeed { get; set; }

    #endregion

    #region Monobehaviour Callbacks

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        lifeTime = 0f;
        rb2d.velocity = Direction * ProjectileSpeed;
    }
    private void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifetime) ShotPool.Instance.ReturnToPool(this);
    }
    #endregion
}
