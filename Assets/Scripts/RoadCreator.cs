using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreator : MonoBehaviour
{
    [SerializeField] float offset = 3.535534f;
    [SerializeField] float spawnTime = 1.25f;
    [SerializeField] Transform startingRoad = null;

    Vector3 lastPos;
    ObjectPooler pooler;

    private void Awake()
    {
        lastPos = startingRoad.position;
        pooler = GetComponent<ObjectPooler>();
    }

    public void Start()
    {
        InvokeRepeating("CreateNewRoadPart", spawnTime, spawnTime);
    }

    private void CreateNewRoadPart()
    {
        Transform roadPart = pooler.GetObject().transform;
        roadPart.position = RandomSpawnPoint();
        roadPart.gameObject.SetActive(true);
        lastPos = roadPart.position;

        pooler.EnqueueObject(roadPart.gameObject);
    }

    private Vector3 RandomSpawnPoint()
    {
        Vector3 spawnPos = lastPos + Vector3.one * offset;
        spawnPos.x += Random.Range(0, 100) < 50 ? 0 : -offset * 2;
        spawnPos.y = lastPos.y;

        return spawnPos;
    }
}
