using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    #region Variables

    //Inspector
    [Space]
    [Header("Input")]
    [SerializeField]
    private FgmInputReader inputReader;
    [Space]
    [Header("Player")]
    [SerializeField]
    private Transform playerHandRotator;
    [Space()]
    [Header("Camera")]
    [SerializeField]
    private Transform cameraTarget;
    [SerializeField]
    private float lookAheadAmount, lookAheadSpeed;

    //Components and References
    private DirectionBehaviour _directionBehaviour;
    private Health _health;

    //Private fields
    private Vector3 mousePosition;
    private Camera cam;

    //Properties
    public Vector3 AimDirection { get; private set; }

    #endregion

    private void Awake()
    {
        TryGetComponent(out _directionBehaviour);
        if (_directionBehaviour == null)
            Debug.LogError("The DirectionBehaviour component could not be found on the game object " + gameObject.name);

        TryGetComponent(out _health);
        if (_health == null)
            Debug.LogError("The Health component could not be found on the game object " + gameObject.name);

        cam = Camera.main;
    }

    private void OnEnable()
    {
        inputReader.AimEvent += Aim;
    }
    private void OnDisable()
    {
        inputReader.AimEvent -= Aim;
    }

    public void Aim(Vector2 aimValue)
    {
        if (_health.CurrentHealth > 0)
        {
            //Get Mouse World Position
            mousePosition = cam.ScreenToWorldPoint(aimValue);
            AimDirection = (mousePosition - playerHandRotator.transform.position).normalized;

            //Aim Hand
            float angle;
            if (_directionBehaviour.FacingDirection == XDirections.Right)
            {
                angle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
            }
            else
            {
                angle = Mathf.Atan2(-AimDirection.y, -AimDirection.x) * Mathf.Rad2Deg;
            }

            playerHandRotator.eulerAngles = new Vector3(0, 0, angle);

            //Move Camera Target
            cameraTarget.localPosition = new Vector3(Mathf.Lerp(cameraTarget.localPosition.x,
                AimDirection.x * lookAheadAmount, lookAheadSpeed * Time.deltaTime),
                cameraTarget.localPosition.y, cameraTarget.localPosition.z);

            //Player Flip Condition
            if (angle > 90 || angle < -90)
                _directionBehaviour.FlipXFacingDirection();
        }
    }
}
