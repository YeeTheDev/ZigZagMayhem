using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreator : MonoBehaviour
{
    [SerializeField] float offset = 0.707f;
    [SerializeField] float spawnTime = 0.5f;
    [SerializeField] Transform startingRoad = null;
    [SerializeField] GameObject roadPrefab = null;

    Vector3 lastPos;

    private void Awake()
    {
        lastPos = startingRoad.position;
    }

    public void Start()
    {
        InvokeRepeating("CreateNewRoadPart", spawnTime, spawnTime);
    }

    private void CreateNewRoadPart()
    {
        Debug.Log("Creating");

        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else { spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset); }

        GameObject newRoadPart = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0), transform);
        lastPos = newRoadPart.transform.position;
    }
}
