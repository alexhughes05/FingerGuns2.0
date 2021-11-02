using System.Collections;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    //Inspector
    [Min(0)]
    [SerializeField]
    private float rotationsPerSecond;
    [SerializeField]
    private bool StartSpinningWhenEnabled;
    [SerializeField]
    [HideInInspector]
    private bool spinInDirectionOfMovement;
    [SerializeField]
    [HideInInspector]
    private RotationDirection rotationDirection;

    //References
    private Rigidbody2D _rb2d;

    //Private fields
    private Coroutine co;

    private void Awake()
    {
        TryGetComponent(out _rb2d);
        if (spinInDirectionOfMovement && _rb2d == null)
            Debug.LogError("spinInDirectionOfMovement has been selected but no Rigidbody2D component could be found on gameObject " + gameObject.name);
    }

    private void OnEnable()
    {
        if (StartSpinningWhenEnabled)
            AttemptToSpin(spinInDirectionOfMovement);
    }

    public void AttemptToSpin(bool spinInDirectionOfMovement)
    {
        rotationsPerSecond = Mathf.Abs(rotationsPerSecond);

        if (spinInDirectionOfMovement == false && rotationDirection == RotationDirection.Clockwise)
            rotationsPerSecond *= -1;

        co = StartCoroutine(SpinUntilStopSignal(spinInDirectionOfMovement, rotationsPerSecond * 360));
    }

    public void StopSpinning()
    {
        StopCoroutine(co);
    }

    private IEnumerator SpinUntilStopSignal(bool spinInDirectionOfMovement, float rotationsPerSecond)
    {
        bool waitingToStartSpin = spinInDirectionOfMovement;

        while (waitingToStartSpin)
        {
            if (_rb2d.velocity.x != 0) //Need to give the object time for the velocity to be set when it's spawned.
            {
                if (_rb2d.velocity.x > 0)
                    rotationsPerSecond *= -1;

                waitingToStartSpin = false;
            }
            yield return null;
        }

        while (true)
        {
            transform.Rotate(0, 0, rotationsPerSecond * Time.deltaTime);
            yield return null;
        }
    }
}
