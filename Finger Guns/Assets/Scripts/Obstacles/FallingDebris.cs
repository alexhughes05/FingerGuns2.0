using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDebris : MonoBehaviour
{
    #region Variables
    //public
    [SerializeField] ObstacleSpawner[] debriSpanwers;

    //Components
    private SmokeAndRocksEffect smokeAndRocksEffect;
    private Eruption eruption;
    #endregion

    private void Awake()
    {
        smokeAndRocksEffect = FindObjectOfType<SmokeAndRocksEffect>();
        eruption = FindObjectOfType<Eruption>();
    }

    public void StartRainingDebris()
    {
        StartCoroutine(RainDebrisForDuration());
    }
    public void StopRainingDebris()
    {
        StopAllCoroutines();
        StopAllObstacleSpawners();
    }

    private IEnumerator RainDebrisForDuration()
    {
        StartAllObstacleSpawners();

        yield return new WaitForSeconds(smokeAndRocksEffect.RocksDuration - eruption.DelayToStartRainingDebris);

        StopAllObstacleSpawners();

    }
    private void StartAllObstacleSpawners()
    {
        foreach (ObstacleSpawner debriSpawner in debriSpanwers)
            debriSpawner.StartObstacleSpawner();
    }

    private void StopAllObstacleSpawners()
    {
        foreach (ObstacleSpawner debriSpawner in debriSpanwers)
            debriSpawner.StopObstacleSpanwer();
    }
    //private IEnumerator SpawnDebris()
    //{
    //    while (true)
    //    {
    //        GameObject selectedDebris = fallingDebris[UnityEngine.Random.Range(0, fallingDebris.Length)];
    //        float sizeMultiplier = UnityEngine.Random.Range(minDebrisSize, maxDebrisSize);
    //        selectedDebris.transform.localScale = Vector3.one * 100f;
    //        selectedDebris.transform.localScale *=  sizeMultiplier;
    //        Vector2 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    //        Vector2 stageLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
    //        Vector2 spawnLocation = new Vector2(UnityEngine.Random.Range(stageLeft.x + 1, stageDimensions.x - 1), stageDimensions.y + 1);
    //        spawnedObject = Instantiate(selectedDebris, spawnLocation, transform.rotation);
    //        spawnedObject.GetComponent<VolcanicRock>().StartRotation = true;
    //        spawnedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fallingRate);
    //        yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeBtwSpawns, maxTimeBtwSpawns));
    //    }
    //}
}
