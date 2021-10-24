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
    //private InputReader fgmInput;

    //Private fields
    private Vector3 mousePosition;
    private Camera cam;

    //Properties
    public Vector3 AimDirection { get; private set; }

    #endregion

    private void Awake()
    {
        _directionBehaviour = GetComponent<DirectionBehaviour>();
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
