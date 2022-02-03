using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour, IITem
{
    [SerializeField] float invincibilityTime = 10f;
    [SerializeField] Color invincibilityColor = Color.blue;
    [SerializeField] AudioClip invincibilityClip = null;

    public IEnumerator UseItem(Transform player, AudioSource audioSource)
    {
        TankCollisioner tankCollisioner = GameObject.FindGameObjectWithTag("Player").GetComponent<TankCollisioner>();
        tankCollisioner.SetInvincibility(invincibilityTime, invincibilityColor);
        audioSource.PlayOneShot(invincibilityClip);

        yield break;
    }
}
