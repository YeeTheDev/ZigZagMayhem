using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] int objectLimit = 0;
    [SerializeField] int startingObjects = 0;
    [SerializeField] bool createsMoreObjects = false;
    [SerializeField] Transform parent = null;
    [SerializeField] GameObject[] alreadySpawnedObjects = null;
    [SerializeField] GameObject objectType = null;

    Queue<GameObject> objectQueue = new Queue<GameObject>();

    private void Awake()
    {
        CreateInitialObjects();
        EnqueueInitialObjects();
    }

    private void EnqueueInitialObjects()
    {
        if (alreadySpawnedObjects.Length <= 0) { return; }

        foreach (GameObject gO in alreadySpawnedObjects)
        {
            objectQueue.Enqueue(gO);
        }
    }

    private void CreateInitialObjects()
    {
        for (int i = 0; i < startingObjects; i++)
        {
            if (objectQueue.Count >= objectLimit) { break; }

            EnqueueObject(CreateNewObject());
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject poolObject = Instantiate(objectType);

        if (parent != null)
        {
            poolObject.transform.position = parent.position;
            poolObject.transform.parent = parent;
        }

        poolObject.SetActive(false);
        return poolObject;
    }

    public GameObject GetObject()
    {
        if (createsMoreObjects && objectQueue.Count <= 0) { return CreateNewObject(); }
        else if(objectQueue.Count <= 0) { return null; }

        return objectQueue.Dequeue();
    }

    public void EnqueueObject(GameObject objectToEnqueue)
    {
        objectQueue.Enqueue(objectToEnqueue);
    }
}
