using UnityEngine;

public class DirectionBehaviour : MonoBehaviour
{
    [SerializeField]
    private XDirections FacingDirectionOnStart;
    public XDirections FacingDirection { get; set;}

    private void Start() => FacingDirection = FacingDirectionOnStart;
    public void FlipXFacingDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        if (FacingDirection == XDirections.Right) 
            FacingDirection = XDirections.Left;
        else 
            FacingDirection = XDirections.Right;
        //firePoint.Rotate(0f, 180f, 0f);
    }
}
