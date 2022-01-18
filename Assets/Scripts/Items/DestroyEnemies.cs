using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour, IITem
{
    public IEnumerator UseItem(Transform t = null)
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.SetActive(false);
        }

        yield break;
    }
}
