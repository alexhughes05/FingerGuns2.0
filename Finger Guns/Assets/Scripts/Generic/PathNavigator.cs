using System;
using UnityEngine;
using System.Collections.Generic;

public class PathNavigator : MonoBehaviour
{
    [SerializeField]
    private bool relativeToScreen;
    [SerializeField]
    private List<Paths> paths;
    [SerializeField] 
    private GameObject[] pathsPrefab;
    [SerializeField]
    private float navigationSpeed;
    [SerializeField]
    private bool executeOnStart;

    //Properties
    public Vector2 InitialSpawnPoint { get; private set; }

    private void Start()
    {
        InitialSpawnPoint = (relativeToScreen) ? paths[0].wayPoints[0] : new Vector2(pathsPrefab[0].transform.position.x, pathsPrefab[0].transform.position.x);

        if (executeOnStart)
            NavigateRandomPath();
    }

    public void NavigateRandomPath()
    {
        GameObject path = pathsPrefab[UnityEngine.Random.Range(0, pathsPrefab.Length)];
        var spawnHeight = path.transform.GetChild(0).position.y;
        var spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 5));
        spawnPoint.y = spawnHeight;
        foreach (Transform child in path.transform)
        {
            //Move towards child
            float step = navigationSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, child.transform.position, step);
        }
        //Instantiate(obstacle, spawnPoint, Quaternion.identity);
    }
}

[Serializable]
struct Paths
{
    public List<Vector2> wayPoints;
}


