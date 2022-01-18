using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour, IITem
{
    [SerializeField] float delayTime;

    public IEnumerator UseItem(Transform t = null)
    {
        Debug.Log("Delaying...");
        yield return new WaitForSeconds(delayTime);
    }
}
