using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour, IITem
{
    [SerializeField] float invincibilityTime = 10f;
    [SerializeField] Material invincibilityMaterial = null;
    [SerializeField] AudioClip invincibilityClip = null;

    public IEnumerator UseItem(Transform player, AudioSource audioSource)
    {
        TankCollisioner tankCollisioner = GameObject.FindGameObjectWithTag("Player").GetComponent<TankCollisioner>();
        tankCollisioner.SetInvincibility(invincibilityTime, invincibilityMaterial);
        audioSource.PlayOneShot(invincibilityClip);

        yield break;
    }
}
