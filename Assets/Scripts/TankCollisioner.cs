using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollisioner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            StartCoroutine(ActivateItem(other.transform));
        }
    }

    private IEnumerator ActivateItem(Transform item)
    {
        List<IITem> itemSequence = item.GetComponent<ItemBuilder>().GetItemSequence();

        foreach (IITem itemToUse in itemSequence)
        {
            yield return itemToUse.UseItem(transform);
        }
    }
}
