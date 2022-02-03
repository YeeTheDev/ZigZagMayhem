using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDecorator : MonoBehaviour, IITem
{
    [SerializeField] float delayTime;
    [SerializeField] MonoBehaviour itemAbility = null;

    public IEnumerator UseItem(Transform player, AudioSource audioSource = null)
    {
        if (transform.childCount > 0 && transform.parent == null)
        {
            transform.parent = player;
            transform.position = player.position;
            transform.GetChild(0).gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(delayTime);

        IITem item = itemAbility as IITem;

        if (item != null) { yield return item.UseItem(player, audioSource); }
    }
}