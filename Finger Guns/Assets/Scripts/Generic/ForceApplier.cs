//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;

//public class ForceApplier : MonoBehaviour
//{
//    #region Inspector
//    [SerializeField]
//    private ForceMode2D forceMode;
//    [SerializeField]
//    private ForceDirection forceDirection;
//    [SerializeField]
//    private Vector2 force;
//    [SerializeField]
//    [HideInInspector]
//    private bool hasMinXForce;
//    [SerializeField]
//    [HideInInspector]
//    private bool hasMinYForce;
//    [SerializeField]
//    [HideInInspector]
//    private float minXForce = Mathf.NegativeInfinity;
//    [SerializeField]
//    [HideInInspector]
//    private float minYForce = Mathf.NegativeInfinity;
//    [SerializeField]
//    [HideInInspector]
//    private bool hasMaxXForce;
//    [SerializeField]
//    [HideInInspector]
//    private bool hasMaxYForce;
//    [SerializeField]
//    [HideInInspector]
//    private float maxXForce = Mathf.Infinity;
//    [SerializeField]
//    [HideInInspector]
//    private float maxYForce = Mathf.Infinity;
//    [SerializeField]
//    [HideInInspector]
//    private Vector2 relativeOffset;
//    [SerializeField]
//    [HideInInspector]
//    private Basic2DAxis axisOverride;
//    [SerializeField]
//    [HideInInspector]
//    private float xAxisForce;
//    [SerializeField]
//    [HideInInspector]
//    private float yAxisForce;
//    [SerializeField]
//    [HideInInspector]
//    private bool forceOverrideWhenStationary;
//    [SerializeField]
//    [HideInInspector]
//    private Vector2 stationaryForceOverride;
//    #endregion

//    private void OnCollisionEnter2D(Collision2D collision) //Want to change to work for trigger, stay2D, etc.
//    {

//        var forceReceiver = (applyToAnyGameObject) ? collision.gameObject : FindForceReceiver(collision.gameObject);

//        if (forceReceiver != null)
//        {
//            var forceReceiverRb2d = GetForceReceiverRb2d(forceReceiver);
//            if (forceReceiverRb2d != null)
//                ApplyForceToReceiver(forceReceiverRb2d);
//            else
//                Debug.LogError("Unable to find the Rigidbody2D component on force receiver " + forceReceiver.name);
//        }
//    }

//    private GameObject FindForceReceiver(GameObject collisionGO)
//    {
//        GameObject foundForceReceiver = null;
//        foreach (GameObject forceReceiver in forceReceivers)
//        {
//            if (forceReceiver == collisionGO) //Might have to change. We'll seee if a prefab and gameobject of different instances will return true.
//                foundForceReceiver = forceReceiver;
//        }
//        return foundForceReceiver;
//    }
//    private Rigidbody2D GetForceReceiverRb2d(GameObject forceReceiver)
//    {
//        forceReceiver.TryGetComponent(out Rigidbody2D forceReceiverRb2d);

//        if (forceReceiverRb2d == null)
//        {
//            var root = forceReceiver.transform.root;
//            forceReceiverRb2d = root.GetComponentInChildren<Rigidbody2D>();
//        }
//        return forceReceiverRb2d;
//    }
//    private void ApplyForceToReceiver(Rigidbody2D forceReceiverRb2d)
//    {
//        switch (forceDirection)
//        {
//            case ForceDirection.vector:
//                ApplyForceOnReceiver(force, forceReceiverRb2d);
//                break;
//            case ForceDirection.applyersVelocity:
//                {
//                    TryGetComponent(out Rigidbody2D forceApplyerRb2d);
//                    if (oppositeForcetoVelocity)
//                        ApplyForceOnReceiver(-forceApplyerRb2d.velocity + relativeOffset, forceReceiverRb2d);
//                    else
//                        ApplyForceOnReceiver(forceApplyerRb2d.velocity + offset, forceReceiverRb2d);
//                }
//                break;
//            case ForceDirection.sumOfVelocities:
//                {
//                    if (oppositeForcetoVelocity)
//                        ApplyForceOnReceiver(-forceReceiverRb2d.velocity + relativeOffset, forceReceiverRb2d);
//                    else
//                        ApplyForceOnReceiver(forceReceiverRb2d.velocity + relativeOffset, forceReceiverRb2d);
//                }
//                break;
//        }
//    }
//    private void ApplyForceOnReceiver(Vector2 force, Rigidbody2D forceReceiverRb2d)
//    {
//        if (forceMode == ForceMode2D.Impulse)
//            forceReceiverRb2d.AddForce(force, ForceMode2D.Impulse);
//        else
//            forceReceiverRb2d.AddForce(force, ForceMode2D.Force);
//    }
//}
