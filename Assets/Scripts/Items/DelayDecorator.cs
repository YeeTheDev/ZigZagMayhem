using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDecorator : MonoBehaviour, IITem
{
    [SerializeField] float delayTime;
    [SerializeField] MonoBehaviour itemAbility = null;

    public IEnumerator UseItem(Transform t = null)
    {
        yield return new WaitForSeconds(delayTime);

        IITem item = itemAbility as IITem;

        if (item != null) { yield return item.UseItem(t); }
    }
}
