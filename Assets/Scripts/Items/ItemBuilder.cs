using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuilder : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] abilities = null;

    List<IITem> itemSequence = new List<IITem>();

    public List<IITem> ItemSequence { get => itemSequence; }

    private void Awake() { CreateItemSequence(); }

    private void CreateItemSequence()
    {
        foreach (MonoBehaviour itemToCheck in abilities)
        {
            IITem item = (IITem)itemToCheck;

            if (item != null)
            {
                itemSequence.Add(item);
            }
        }

        foreach (IITem item in itemSequence)
        {
            Debug.Log(item.ToString());
        }
    }
}
