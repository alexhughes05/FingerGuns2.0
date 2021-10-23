using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundedChecker : MonoBehaviour
{
    //Inspector
    [SerializeField]
    private LayerMask groundLayer;

    //References
    private Collider2D _col;
    private Rigidbody2D _rb2d;
    private PlayerPhysicsMatSwapper _playerPhysicsMatSwapper;

    //Fields
    private RaycastHit2D raycastHit;
    private readonly float extraHeight = 0.05f;
    private bool frictionTurnedOff = true;

    //Properties
    public bool Grounded { get; set; }
    public bool WasGrounded { get; set; }

    private void Awake()
    {
        TryGetComponent<Collider2D>(out _col);
        TryGetComponent<Rigidbody2D>(out _rb2d);
        TryGetComponent<PlayerPhysicsMatSwapper>(out _playerPhysicsMatSwapper);
    }

    protected virtual void Update() => ExecuteGroundedCheck();

    private void ExecuteGroundedCheck()
    {
        raycastHit = Physics2D.BoxCast(_col.bounds.center, _col.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);

        if (raycastHit.collider != null) //GROUNDED
        {
            if (frictionTurnedOff == true && _rb2d != null && _playerPhysicsMatSwapper != null)
            {
                _playerPhysicsMatSwapper.TurnOnFriction(_rb2d);
                frictionTurnedOff = false;
            }
            DrawUpdatedRay(Color.green);
        }
        else //NOT GROUNDED 
        {
            if (frictionTurnedOff == false && _rb2d != null && _playerPhysicsMatSwapper != null)
            {
                _playerPhysicsMatSwapper.TurnOffFriction(_rb2d);
                frictionTurnedOff = true;
            }
            DrawUpdatedRay(Color.red);
        }
                            
        Grounded = raycastHit.collider != null;
    }

    protected void DrawUpdatedRay(Color rayColor)
    {
        Debug.DrawRay(_col.bounds.center + new Vector3(_col.bounds.extents.x, 0), Vector2.down * (_col.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(_col.bounds.center - new Vector3(_col.bounds.extents.x, 0), Vector2.down * (_col.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(_col.bounds.center - new Vector3(0, _col.bounds.extents.x, _col.bounds.extents.y + extraHeight), Vector2.right * (_col.bounds.extents.x), rayColor);
    }
}
