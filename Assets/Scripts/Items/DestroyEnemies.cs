using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour, IITem
{
    [SerializeField] AudioClip thunderClip = null;

    public IEnumerator UseItem(Transform t = null, AudioSource audioSource = null)
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Enemy>().PlayDestroyEffect();
        }

        audioSource.PlayOneShot(thunderClip);

        yield break;
    }
}
