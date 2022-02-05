using System.Collections;
using UnityEngine;

public class DelayDecorator : MonoBehaviour, IITem
{
    [SerializeField] float delayTime = 5f;
    [SerializeField] Transform visualEffect = null;
    [SerializeField] MonoBehaviour itemAbility = null;

    public IEnumerator UseItem(Transform player, AudioSource audioSource = null)
    {
        if (transform.childCount > 0 && transform.parent == null)
        {
            transform.parent = player;
            transform.position = player.position;
            visualEffect.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(delayTime);

        IITem item = itemAbility as IITem;

        if (item != null) { yield return item.UseItem(player, audioSource); }
    }
}