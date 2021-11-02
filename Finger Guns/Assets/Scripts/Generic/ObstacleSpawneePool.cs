using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawneePool : GenericObjectPool<ObstacleSpawnee>
{
    #region Variables
    //Inspector
    [SerializeField]
    [HideInInspector]
    private float _minSpawnRateInSeconds;
    [SerializeField]
    [HideInInspector]
    private float _maxSpawnRateInSeconds;
    [SerializeField]
    [HideInInspector]
    private SpawnPositionTypes _spawnType;
    [SerializeField]
    [HideInInspector]
    private List<TransformSpawnPoint> _possibleTransformSpawnPoints;
    [SerializeField]
    [HideInInspector]
    private List<RelativeSpawnPoint> _possibleRelativeSpawnPoints;

    //References

    //private fields
    private Camera cam;

    //properties
    public bool PoolIsReadyForSpawner { get; set; }
    public Vector3 InitialVelocity { get; private set; }
    #endregion

    private void Awake()
    {
        cam = Camera.main;
    }

    public IEnumerator SetPoolBackToReadyAfterDelay()
    {
        PoolIsReadyForSpawner = false;
        float timeToWait = UnityEngine.Random.Range(_minSpawnRateInSeconds, _maxSpawnRateInSeconds);
        yield return new WaitForSeconds(timeToWait);
        PoolIsReadyForSpawner = true;
    }

    public Vector2 GetNextSpawnLocation(SpawnPoint spawnPoint)
    {
        var spawnLocation = Vector2.zero;

        if (spawnPoint is TransformSpawnPoint currentTransformSpawnPoint)
        {
            spawnLocation = currentTransformSpawnPoint.transformSpawnPoint.position;
        }
        else if (spawnPoint is RelativeSpawnPoint currentRelativeSpawnPoint)
        {
            spawnLocation.x = (currentRelativeSpawnPoint.screenPosition.x / 100) * Screen.width;
            spawnLocation.y = (currentRelativeSpawnPoint.screenPosition.y / 100) * Screen.height;
            spawnLocation = cam.ScreenToWorldPoint(spawnLocation);
        }

        return spawnLocation;
    }
    public Vector2 GetNextInitialVelocity(SpawnPoint spawnPoint)
    {
        return spawnPoint.initialVelocity;
    }
    public SpawnPoint GetNextSpawnPoint()
    {
        int index = 0;

        if (_spawnType == SpawnPositionTypes.Absolute)
        {
            if (_possibleTransformSpawnPoints.Count > 1)
                index = UnityEngine.Random.Range(0, _possibleTransformSpawnPoints.Count);

            return _possibleTransformSpawnPoints[index];
        }
        else
        {
            if (_possibleRelativeSpawnPoints.Count > 1)
                index = UnityEngine.Random.Range(0, _possibleRelativeSpawnPoints.Count);

            return _possibleRelativeSpawnPoints[index];
        }
    }
}

[Serializable]
public abstract class SpawnPoint
{
    public Vector2 initialVelocity;
}

[Serializable]
public class TransformSpawnPoint : SpawnPoint
{
    public Transform transformSpawnPoint;
}

[Serializable]
public class RelativeSpawnPoint : SpawnPoint
{
    public Vector2 screenPosition;
}
