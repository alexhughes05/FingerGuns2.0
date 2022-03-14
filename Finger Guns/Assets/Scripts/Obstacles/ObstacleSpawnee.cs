using UnityEngine;

public class ObstacleSpawnee : MonoBehaviour, IPoolable
{
    #region Variables
    //Inspector
    [SerializeField]
    [HideInInspector]
    private bool _hasMaxLifetime;
    [SerializeField]
    [HideInInspector]
    private float _timeUntilDestroyed;

    //References
    private Rigidbody2D _rb2d;

    //Private fields
    private float _endOfLifeTime;
    private Vector3 initialScale;

    //Properties
    public GameObjectPool AssociatedPool { get; set; }
    #endregion

    private void Awake()
    {
        TryGetComponent(out _rb2d);
        if (_rb2d == null)
            Debug.LogError("Unable to find Rigidbody2D component on gameobject " + gameObject.name);
    }

    private void Update()
    {
        if (_hasMaxLifetime)
        {
            if (Time.time >= _endOfLifeTime)
                AssociatedPool.ReturnToPool(gameObject);
        }
    }
    
    public void SetEndOfLifeTime()
    {
        _endOfLifeTime = Time.time + _timeUntilDestroyed;
    }

    public void SetSpawnLocation(Vector3 spawnPos)
    {
        transform.position = spawnPos;
    }
    public void SetScaleSize(float sizeMultiplier)
    {
        initialScale = transform.localScale;
        transform.localScale = initialScale * sizeMultiplier;
    }
    public void SetVelocity(Vector3 initialVelocity)
    {
        _rb2d.velocity = initialVelocity;
    }
    private void OnDisable()
    {
        if (initialScale != Vector3.zero)
            transform.localScale = initialScale;
    }
}

