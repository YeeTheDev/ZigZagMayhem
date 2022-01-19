using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] int roadsBeforeItem = 10;
    [SerializeField] int chanceToSpawnItem = 10;
    [SerializeField] GameObject[] items = null;

    int roadCounter;

    public void CheckIfItemSpawns(Vector3 roadPosition)
    {
        roadCounter++;

        if (roadCounter >= roadsBeforeItem)
        {
            int increasedChangeToItem = chanceToSpawnItem + roadCounter;

            if (Random.Range(0, 100) < increasedChangeToItem)
            {
                roadCounter = 0;

                int randomItem = Random.Range(0, items.Length - 1);
                GameObject item = Instantiate( items[randomItem]);

                roadPosition.y = item.transform.position.y;
                item.transform.position = roadPosition;
            }
        }
    }
}
