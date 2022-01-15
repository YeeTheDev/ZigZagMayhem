using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToReuse = 4;

    BulletPooler pooler;

    public BulletPooler SetPooler { set => pooler = value; }

    private void OnEnable() { StartCoroutine(DisableBullet()); }
    private void OnDisable() { pooler.EnqueueObject(gameObject); }

    private IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(timeToReuse);

        gameObject.SetActive(false);
    }
}
