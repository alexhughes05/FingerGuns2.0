using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    //Inspector
    [SerializeField]
    private FgmInputReader _inputReader;
    [Space]
    [SerializeField]
    private float defaultMaxSpeed;

    //Fields
    private Vector2 MovementVector;
    private float currentMaxSpeed;

    //Components and References
    private Mover mover;
    private Rigidbody2D _rb2d;

    //Properties
    public float PreviousMaxSpeed { get; private set; } //Can always access to reset back to the original max speed.
    public bool MovementInputDisabled { get; set; } //When the player experiences external forces, since the velocity is being modified directly with player movement, you don't want it to override this external force.

    public XDirections CurrentMovementDirection { get; private set; }
    public float CurrentMaxSpeed
    {
        get => currentMaxSpeed;
        set
        {
            PreviousMaxSpeed = currentMaxSpeed;
            if (MovementInputDisabled)
                return;
            currentMaxSpeed = value;
        }
    }

    private void OnEnable()
    {
        _inputReader.StartMovingEvent += OnStartWalkingInitiated;
        _inputReader.StopMovingEvent += OnStopWalkingInitiated;
    }
    private void OnDisable()
    {
        _inputReader.StartMovingEvent -= OnStartWalkingInitiated;
        _inputReader.StopMovingEvent -= OnStopWalkingInitiated;
    }

    private void Awake()
    {
        mover = new Mover();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CurrentMaxSpeed = defaultMaxSpeed;
    }

    private void FixedUpdate()
    {
        if ((CurrentMovementDirection != XDirections.None && MovementInputDisabled == false))
        {
            MovementVector.y = _rb2d.velocity.y;
            _rb2d.velocity = MovementVector;
        }
    }

    public void OnStartWalkingInitiated(XDirections moveDirection)
    {
        CurrentMovementDirection = moveDirection;
        ApplyMovement();
    }

    public void OnStopWalkingInitiated()
    {
        CurrentMovementDirection = XDirections.None;
        MovementVector.x = 0;

        if (MovementInputDisabled == false)
            _rb2d.velocity = MovementVector;
    }
    public void ApplyMovement() => MovementVector = mover.CalculateXMovement(CurrentMovementDirection, CurrentMaxSpeed);

    public class Mover
    {
        private Vector2 movementVector = Vector2.zero;
        public Vector2 CalculateXMovement(XDirections moveDirection, float maxSpeed)
        {
            movementVector.x = (float)moveDirection * maxSpeed;
            return movementVector;
        }
    }
}
