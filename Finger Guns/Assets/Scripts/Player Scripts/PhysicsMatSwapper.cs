using UnityEngine;
public class PhysicsMatSwapper : MonoBehaviour
{
    //Inspector
    [Header("Physics Materials")]
    [SerializeField]
    private PhysicsMaterial2D frictionMaterial;
    [SerializeField]
    private PhysicsMaterial2D noFrictionMaterial;

    public void TurnOnFriction(Rigidbody2D rb2d) => rb2d.sharedMaterial = frictionMaterial;
    public void TurnOffFriction(Rigidbody2D rb2d) => rb2d.sharedMaterial = noFrictionMaterial;
}
