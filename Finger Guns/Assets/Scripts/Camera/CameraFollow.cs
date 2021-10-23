using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables
    //public
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;

    //Components
    private StopCameraMovement cameraMovementScript;
    private FgmInputHandler player;

    //private
    private bool stopCameraFollow;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        player = FindObjectOfType<FgmInputHandler>();
    }

    #endregion
    private void LateUpdate()
    {
            MoveCamera();
    }

    private void MoveCamera()
    {
        var desiredPos = target.position + offset;
        var smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed);
        transform.position = smoothedPos;
    }

    public void StopCameraFollow()
    {
        stopCameraFollow = true;
    }

    public void ResumeCameraFollow()
    {
        stopCameraFollow = false;
    }
}
