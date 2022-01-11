using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    Vector3 vectorOffset;
    Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        vectorOffset = player.position - transform.position;
    }

    private void LateUpdate()
    {
        Vector3 followPosition = player.position - vectorOffset;

        transform.position = followPosition;
    }
}
