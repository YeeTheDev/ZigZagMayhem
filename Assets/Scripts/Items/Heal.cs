using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour, IITem
{
    public IEnumerator UseItem(Transform player)
    {
        player.GetComponent<PlayerStats>().UpdateHealth(1);
        yield break;
    }
}
