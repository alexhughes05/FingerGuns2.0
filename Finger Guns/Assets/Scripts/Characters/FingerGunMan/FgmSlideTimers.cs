using UnityEngine;

public class FgmSlideTimers : MonoBehaviour
{
    //Inspector
    [SerializeField]
    private float maxSlideDuration;
    [SerializeField]
    private float minTimeBtwSlides;

    public float TimeWhenSlideEnds { get; set; } = Mathf.NegativeInfinity;
    public float TimeWhenCanSlideAgain { get; private set; }

    public void StartMaxSlideDurationTimer() => TimeWhenSlideEnds = Time.time + maxSlideDuration;
    public void StartTimeBtwSlidesTimer() => TimeWhenCanSlideAgain = Time.time + minTimeBtwSlides;
}
