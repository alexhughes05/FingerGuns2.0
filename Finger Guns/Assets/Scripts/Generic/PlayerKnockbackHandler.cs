using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerKnockbackHandler : MonoBehaviour, IKnockbackable
{
    //private fields
    private Rigidbody2D _rb2d;

    //Properties
    public bool PlayerKnockedback { get; set; }
    public Vector2 KnockbackForce { get; private set; }

    private void Awake()
    {
        TryGetComponent(out _rb2d);
    }
    public void HandleKnockback(Vector3 force)
    {
        //KnockbackForce = ((Vector2)force == Vector2.zero) ? -_rb2d.velocity : (Vector2)force;
        //PlayerKnockedback = true;
    }

}
