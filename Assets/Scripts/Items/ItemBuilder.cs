using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuilder : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] abilities = null;

    List<IITem> itemSequence = new List<IITem>();

    Collider col;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        col = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();

        CreateItemSequence();
    }

    private void CreateItemSequence()
    {
        foreach (MonoBehaviour itemToCheck in abilities)
        {
            IITem item = itemToCheck as IITem;

            if (item != null)
            {
                itemSequence.Add(item);
            }
        }
    }

    public List<IITem> GetItemSequence()
    {
        col.enabled = false;
        meshRenderer.enabled = false;

        return itemSequence;
    }
}
