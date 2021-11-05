using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public static GameObjectPool Instance { get; private set; }
    private readonly Queue<GameObject> objects = new Queue<GameObject>();
    private void Awake()
    {
        Instance = this;
    }

    public GameObject Get()
    {
        if (objects.Count == 0)
            AddObjects(1);
        return objects.Dequeue();
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
    private void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newObject = Instantiate(prefab, gameObject.transform);
            newObject.gameObject.SetActive(false);
            objects.Enqueue(newObject);
            newObject.GetComponent<IPoolable>().AssociatedPool = this;
        }
    }
}
