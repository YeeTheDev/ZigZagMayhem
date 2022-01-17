using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 0;

    Transform player;

    private void Awake() { player = GameObject.FindGameObjectWithTag("Player").transform; }

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
            Debug.Log("Take that biatch!");
        }
    }
}
