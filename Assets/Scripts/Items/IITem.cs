using System.Collections;
using UnityEngine;

public interface IITem
{
    IEnumerator UseItem(Transform t = null, AudioSource audioSource = null);
}