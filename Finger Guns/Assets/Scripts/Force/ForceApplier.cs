using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplier
{
    private Rigidbody2D _rb2d;
    public ForceApplier(Rigidbody2D rb2d)
    {
        _rb2d = rb2d;
    }
    private void ApplyStandardForce(Vector3 force, bool additiveToVelocity = false)
    {

    }

    private void ApplyForceBasedOnDirection(Vector3 forceMagnitude, bool additiveToVelocity = false)
    {

    }
    
}
