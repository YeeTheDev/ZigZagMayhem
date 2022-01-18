using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollisioner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            StartCoroutine(ActivateItem(other.GetComponent<ItemBuilder>().ItemSequence));
        }
    }

    private IEnumerator ActivateItem(List<IITem> itemSequence)
    {
        foreach (IITem item in itemSequence)
        {
            yield return item.UseItem(transform);
        }

        Debug.Log("Finished Using Item");
    }
}
