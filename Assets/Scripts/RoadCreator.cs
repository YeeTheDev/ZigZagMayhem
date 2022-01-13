using System.Collections.Generic;
using UnityEngine;

public class RoadCreator : MonoBehaviour
{
    [Tooltip("The value will be squared")]
    [Range(0, 100)][SerializeField] float distanceToRelocate = 5;
    [SerializeField] float offset = 3.535534f;

    float sqrDistanceLimit;
    Vector3 lastPos;
    Transform player;
    Dictionary<string, Animator> animators = new Dictionary<string, Animator>();

    private void Awake()
    {
        sqrDistanceLimit = distanceToRelocate * distanceToRelocate;
        lastPos = transform.GetChild(transform.childCount - 1).position;
        player = GameObject.FindWithTag("Player").transform;

        CreateAnimatorsDictionary();
    }

    private void CreateAnimatorsDictionary()
    {
        foreach (Transform child in transform)
        {
            animators.Add(child.name, child.GetComponent<Animator>());
        }
    }

    private void Update() { CheckPlayerDistance(); }

    private void CheckPlayerDistance()
    {
        if ((player.position - lastPos).sqrMagnitude <= sqrDistanceLimit) { RelocateRoadPart(); }
    }

    private void RelocateRoadPart()
    {
        Transform roadPart = transform.GetChild(0);
        animators[roadPart.name].SetTrigger("Relocate");

        roadPart.position = RandomNextPosition();
        roadPart.SetAsLastSibling();
        lastPos = roadPart.position;
    }

    private Vector3 RandomNextPosition()
    {
        Vector3 spawnPos = lastPos + Vector3.one * offset;
        spawnPos.x += Random.Range(0, 100) < 50 ? 0 : -offset * 2;
        spawnPos.y = lastPos.y;

        return spawnPos;
    }
}
