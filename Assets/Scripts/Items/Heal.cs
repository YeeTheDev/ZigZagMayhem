using System.Collections;
using UnityEngine;

public class Heal : MonoBehaviour, IITem
{
    [SerializeField] AudioClip healSound = null;

    public IEnumerator UseItem(Transform player, AudioSource audioSource)
    {
        player.GetComponent<PlayerStats>().UpdateHealth(1);
        audioSource.PlayOneShot(healSound);

        yield break;
    }
}
