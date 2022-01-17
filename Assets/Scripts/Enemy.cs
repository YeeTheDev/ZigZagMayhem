using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] float respawnTime = 5f;
    [SerializeField] float minSpawnDistance = -10f;
    [SerializeField] float maxSpawnDistance = 10f;

    Transform player;
    PlayerStats playerStats;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = player.GetComponent<PlayerStats>();
        gameObject.SetActive(false);
    }

    private void Update() { FollowPlayer(); }

    private void FollowPlayer()
    {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            playerStats.UpdateHealth(-1);
        }
    }

    private void OnDisable() { Invoke("Spawn", Random.Range(1, respawnTime)); }

    private void Spawn()
    {
        transform.position = CalculateSpawnPoint();
        gameObject.SetActive(true);
    }

    private Vector3 CalculateSpawnPoint()
    {
        Vector3 respawnPoint = player.position;
        respawnPoint.x += Random.Range(minSpawnDistance, maxSpawnDistance);
        respawnPoint.z += Random.Range(maxSpawnDistance / 2, maxSpawnDistance);
        respawnPoint.y = 1;
        return respawnPoint;
    }
}
