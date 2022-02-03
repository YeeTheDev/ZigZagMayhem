using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] float shakeIntensity = 0.2f;
    [SerializeField] float shakeTime = 0.25f;

    float shakeTimer;
    Vector3 vectorOffset;
    Transform player;

    public void IncreaseShakeTimer() { shakeTimer += shakeTime; }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        vectorOffset = player.position - transform.position;
    }

    private void LateUpdate()
    {
        Vector3 followPosition = player.position - vectorOffset;

        if (shakeTimer > 0)
        {
            followPosition.x += Random.Range(-shakeIntensity, shakeIntensity);
            followPosition.y += Random.Range(-shakeIntensity, shakeIntensity);

            shakeTimer -= Time.deltaTime;
        }

        transform.position = followPosition;
    }
}
