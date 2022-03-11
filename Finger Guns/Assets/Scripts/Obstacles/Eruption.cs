using System.Collections;
using UnityEngine;
using EZCameraShake;

public class Eruption : MonoBehaviour
{
    //public
    [Space()]
    [Header("Volcano Rumble Info")]
    [SerializeField] float magnitudeValue;
    [SerializeField] float roughnessValue;
    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;
    [Space()]
    [Header("Time Info")]
    public float rumbleTimeBeforeSmoke;
    public float totalEruptionLength;

    //Components
    private SmokeAndRocksEffect smokeAndRocksEffect;
    private FallingDebris debris;
    private CameraShakeInstance shaker;

    private void Awake()
    {
        smokeAndRocksEffect = FindObjectOfType<SmokeAndRocksEffect>();
        debris = FindObjectOfType<FallingDebris>();
    }

    public void StartEruption()
    {
        StartCoroutine(StartShaking());
    }
    public void StopEruption()
    {
        shaker.StartFadeOut(fadeOutTime);
        shaker.UpdateShake();
        StopAllCoroutines();
        smokeAndRocksEffect.StopRocksEffect();
        smokeAndRocksEffect.StopSmokeEffect();
        debris.StopRainingDebris();
    }

    private IEnumerator StartShaking()
    {
        shaker = CameraShaker.Instance.StartShake(magnitudeValue, roughnessValue, fadeInTime);
        yield return new WaitForSeconds(rumbleTimeBeforeSmoke);
        smokeAndRocksEffect.StartSmokeEffect();
        StartCoroutine(StartRockEffect());
    }

    private IEnumerator StartRockEffect()
    {
        yield return new WaitForSeconds(smokeAndRocksEffect.RocksDelayAfterSmoke);
        smokeAndRocksEffect.StartRocksEffect();
        StartCoroutine(StartRainingDebris());
    }

    private IEnumerator StartRainingDebris()
    {
        yield return new WaitForSeconds(DelayToStartRainingDebris);
        debris.StartRainingDebris();
        StartCoroutine(StopShaking());
    }

    private IEnumerator StopShaking()
    {
        yield return new WaitForSeconds(smokeAndRocksEffect.RocksDuration - DelayToStartRainingDebris);
        shaker.StartFadeOut(fadeOutTime);
        shaker.UpdateShake();
    }

    //Properties
    public float DelayToStartRainingDebris { get; set; } = 3;
}
