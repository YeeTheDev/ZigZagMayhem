using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] GameObject objectType;
    [SerializeField] int startingObjects;
    [SerializeField] bool createsMoreObjects = true;
    [SerializeField] Transform parent;
    [SerializeField] GameObject[] alreadySpawnedObjects;

    Queue<GameObject> objectQueue = new Queue<GameObject>();

    private void Awake()
    {
        EnqueueInitialObjects();
        CreateInitialObjects(parent);
    }

    private void EnqueueInitialObjects()
    {
        if (alreadySpawnedObjects.Length <= 0) { return; }

        foreach (GameObject gO in alreadySpawnedObjects)
        {
            objectQueue.Enqueue(gO);
        }
    }

    private void CreateInitialObjects(Transform parent = null)
    {
        for (int i = 0; i < startingObjects; i++)
        {
            EnqueueObject(CreateNewObject());
        }
    }

    private GameObject CreateNewObject(Transform parent = null)
    {
        GameObject poolObject = Instantiate(objectType);

        if (parent != null)
        {
            poolObject.transform.position = parent.position;
            poolObject.transform.parent = parent;
        }

        return poolObject;
    }

    public GameObject GetObject()
    {
        if (createsMoreObjects && objectQueue.Count <= 0)
        {
            return CreateNewObject();
        }

        return objectQueue.Dequeue();
    }

    public void EnqueueObject(GameObject objectToEnqueue)
    {
        objectQueue.Enqueue(objectToEnqueue);
        objectToEnqueue.SetActive(false);
    }
}
