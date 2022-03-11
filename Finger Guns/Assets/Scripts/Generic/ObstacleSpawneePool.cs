using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawneePool : GameObjectPool
{
    #region Variables
    //Inspector
    [SerializeField]
    [HideInInspector]
    private EditorValueType spawnRateValueType;
    [SerializeField]
    [HideInInspector]
    private float spawnRateInSeconds;
    [SerializeField]
    [HideInInspector]
    private float _minSpawnRateInSeconds;
    [SerializeField]
    [HideInInspector]
    private float _maxSpawnRateInSeconds;

    [SerializeField]
    [HideInInspector]
    private SpawnPositionType _spawnType;
    [SerializeField]
    [HideInInspector]
    private List<TransformSpawnPoint> _possibleTransformSpawnPoints;
    [SerializeField]
    [HideInInspector]
    private List<RelativeSpawnPoint> _possibleRelativeSpawnPoints;

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
        float timeToWait;
        PoolIsReadyForSpawner = false;

        if (spawnRateValueType == EditorValueType.Constant)
            timeToWait = spawnRateInSeconds;
        else
            timeToWait = UnityEngine.Random.Range(_minSpawnRateInSeconds, _maxSpawnRateInSeconds);
        yield return new WaitForSeconds(timeToWait);
        PoolIsReadyForSpawner = true;
    }

    public Vector2 GetNextSpawnLocation(SpawnPoint spawnPoint)
    {
        var spawnLocation = Vector2.zero;

        if (spawnPoint is TransformSpawnPoint currentTransformSpawnPoint)
        {
            if (currentTransformSpawnPoint.spawnPointValueType == EditorValueType.RandomBetweenTwoConstants)
            {
                var randomX = UnityEngine.Random.Range(currentTransformSpawnPoint.topLeftTransform.position.x, currentTransformSpawnPoint.bottomRightTransform.position.x);
                var randomY = UnityEngine.Random.Range(currentTransformSpawnPoint.bottomRightTransform.position.y, currentTransformSpawnPoint.topLeftTransform.position.y);
                spawnLocation.x = randomX;
                spawnLocation.y = randomY;
            }
            else
                spawnLocation = currentTransformSpawnPoint.transformSpawnPoint.position;
        }
        else if (spawnPoint is RelativeSpawnPoint currentRelativeSpawnPoint)
        {
            if (currentRelativeSpawnPoint.spawnPointValueType == EditorValueType.RandomBetweenTwoConstants)
            {
                currentRelativeSpawnPoint.screenPosition.x = UnityEngine.Random.Range(currentRelativeSpawnPoint.minScreenWidthOffset + currentRelativeSpawnPoint.minScreenWidth, currentRelativeSpawnPoint.maxScreenWidthOffset + currentRelativeSpawnPoint.maxScreenWidth);
                currentRelativeSpawnPoint.screenPosition.y = UnityEngine.Random.Range(currentRelativeSpawnPoint.minScreenHeightOffset + currentRelativeSpawnPoint.minScreenHeight, currentRelativeSpawnPoint.maxScreenHeightOffset + currentRelativeSpawnPoint.maxScreenHeight);
            }
            else
            {
                currentRelativeSpawnPoint.screenPosition.x += currentRelativeSpawnPoint.screenWidthPosOffset;
                currentRelativeSpawnPoint.screenPosition.y += currentRelativeSpawnPoint.screenHeightPosOffset;
            }
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
    public float GetNextSizeMultiplier(SpawnPoint spawnPoint)
    {
        return UnityEngine.Random.Range(spawnPoint.minScaleMultiplier, spawnPoint.maxScaleMultiplier);
    }

    public SpawnPoint GetNextSpawnPoint()
    {
        int index = 0;

        if (_spawnType == SpawnPositionType.Absolute)
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
    public float minScaleMultiplier;
    public float maxScaleMultiplier;
    public EditorValueType spawnPointValueType;
}

[Serializable]
public class TransformSpawnPoint : SpawnPoint
{
    public Transform transformSpawnPoint;
    public Transform topLeftTransform;
    public Transform bottomRightTransform;
}

[Serializable]
public class RelativeSpawnPoint : SpawnPoint
{
    public Vector2 screenPosition;
    public float minScreenWidth;
    public float maxScreenWidth;
    public float minScreenHeight;
    public float maxScreenHeight;
    public float screenWidthPosOffset;
    public float screenHeightPosOffset;
    public float minScreenWidthOffset;
    public float maxScreenWidthOffset;
    public float minScreenHeightOffset;
    public float maxScreenHeightOffset;
}
