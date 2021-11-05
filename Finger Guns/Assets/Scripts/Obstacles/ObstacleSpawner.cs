using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    #region Variables
    //public
    //[SerializeField] bool looping = false;

    [SerializeField] 
    ObstacleSpawneePool[] obstaclePools;
    [Min(0)]
    [Tooltip("This allows you to ensure a minimum amount of time has passed before the obstacle spawner spawns another obstacle.")]
    [SerializeField]
    float minTimeBtwSpawnedObjects;

    //Components
    //private Blade blade;
    //private Lightning lightning;
    //private Wind wind;

    //private fields
    private Coroutine _co;
    private List<ObstacleSpawneePool> _obstaclePoolsPending = new List<ObstacleSpawneePool>();
    private bool _currentlySpawning;

    //Properties
    public List<ObstacleSpawneePool> ObstaclePoolsReadyForUse { get; set; } = new List<ObstacleSpawneePool>();
    #endregion

    private void Start()
    {
        foreach (var obstaclePool in obstaclePools)
            ObstaclePoolsReadyForUse.Add(obstaclePool);
        StartObstacleSpawner();
    }

    public void StartObstacleSpawner()
    {
        _currentlySpawning = true;
        _co = StartCoroutine(SpawnRandomObstacleInQueue());
    }

    public void StopObstacleSpanwer()
    {
        _currentlySpawning = false;
        StopCoroutine(_co);
    }

    public IEnumerator SpawnRandomObstacleInQueue()
    {
        while (_currentlySpawning)
        {
            AddBackPoolsReadyForUse();
            if (ObstaclePoolsReadyForUse.Count > 0)
            {
                ObstacleSpawneePool obstaclePool = ObstaclePoolsReadyForUse[UnityEngine.Random.Range(0, ObstaclePoolsReadyForUse.Count)];
                StartCoroutine(obstaclePool.SetPoolBackToReadyAfterDelay());
                ObstaclePoolsReadyForUse.Remove(obstaclePool);
                _obstaclePoolsPending.Add(obstaclePool);
                ObstacleSpawnee obstacle = obstaclePool.Get().GetComponent<ObstacleSpawnee>();
                obstacle.AssociatedPool = obstaclePool;
                obstacle.SetEndOfLifeTime();
                SpawnPoint spawnPoint = obstaclePool.GetNextSpawnPoint();
                obstacle.SetSpawnLocation(obstaclePool.GetNextSpawnLocation(spawnPoint));
                obstacle.gameObject.SetActive(true);
                obstacle.SetVelocity(obstaclePool.GetNextInitialVelocity(spawnPoint));
                yield return new WaitForSeconds(minTimeBtwSpawnedObjects);
            }
            yield return null;
        }
    }
    private void AddBackPoolsReadyForUse()
    {
        for (int i = 0; i < _obstaclePoolsPending.Count; i++)
        {
            ObstacleSpawneePool pendingPool = _obstaclePoolsPending[i];
            if (pendingPool.PoolIsReadyForSpawner)
            {
                pendingPool.PoolIsReadyForSpawner = false;
                if (!ObstaclePoolsReadyForUse.Contains(pendingPool))
                    ObstaclePoolsReadyForUse.Add(pendingPool);
            }
        }
    }

    //IEnumerator Start()
    //{
    //    do
    //    {
    //        ObstacleSpawnee obstacle = obstacles[Random.Range(0, obstacles.Length)];
    //        yield return StartCoroutine(SpawnObstacles(obstacle));
    //    }
    //    while (looping && (FindObjectOfType<PlayerHealth>()?.CurrentHealth > 0));
    //}

    //private IEnumerator SpawnObstacles(ObstacleSpawnee obstacle)
    //{
    //    //Projectile shot = shotPool.Get();


    //    blade.SelectedPath = blade.getPaths()[UnityEngine.Random.Range(0, blade.getPaths().Length)];
    //    var spawnHeight = blade.SelectedPath.transform.GetChild(0).position.y;

    //    var spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 5));
    //    spawnPoint.y = spawnHeight;
    //    Instantiate(obstacle, spawnPoint, Quaternion.identity);

    //    yield return new WaitForSeconds(UnityEngine.Random.Range(blade.getMinSpawnRateInSeconds(), blade.getMaxSpawnRateInSeconds()));
    //}
}
