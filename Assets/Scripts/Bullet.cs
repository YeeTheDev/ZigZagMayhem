using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToReuse = 4;

    int timesEnqueue;
    ObjectPooler pooler;

    public ObjectPooler SetPooler { set => pooler = value; }

    private void OnEnable()
    {
        StartCoroutine(DisableBullet());
    }

    private IEnumerator DisableBullet()
    {
        timesEnqueue++;
        if (timesEnqueue <= 1) { yield break; }

        yield return new WaitForSeconds(timeToReuse);

        gameObject.SetActive(false);
        pooler.EnqueueObject(gameObject);
    }
}
