using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour, IITem
{
    public IEnumerator UseItem(Transform t = null)
    {
        Debug.Log("You are invincible!");
        yield break;
    }
}
