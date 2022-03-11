using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicRock : MonoBehaviour
{
    //public
    [SerializeField] float minRotationSpeed;
    [SerializeField] float maxRotationSpeed;

    //Components
    private Rigidbody2D rb2d;
    private bool firstTime = true;
    private float rotationSpeed;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (StartRotation)
        {
            if (firstTime)
            {
                firstTime = false;
                rotationSpeed = UnityEngine.Random.Range(minRotationSpeed, maxRotationSpeed);
                rotationSpeed *= Random.Range(0, 2) * 2 - 1; //is either -1 or 1. Used to pick the direction to rotate
            }
            rb2d.rotation += rotationSpeed  * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            Destroy(gameObject);

        if (collider.gameObject.layer == LayerMask.NameToLayer("Ground") || collider.gameObject.layer == LayerMask.NameToLayer("Platform"))
            Destroy(gameObject);
    }

    public bool StartRotation { get; set; }
}
