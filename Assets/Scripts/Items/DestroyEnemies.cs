using System.Collections;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour, IITem
{
    [SerializeField] int maxEnemiesToDestroy = 3;
    [SerializeField] MonoBehaviour destroyDecorator = null;
    [SerializeField] AudioClip thunderClip = null;

    IITem effectOnDestroy;

    private void Awake() { effectOnDestroy = (IITem)destroyDecorator; }

    public IEnumerator UseItem(Transform player, AudioSource audioSource)
    {
        int destroyedEnemies = 0;
        foreach (GameObject enemyToDestroy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (destroyedEnemies >= maxEnemiesToDestroy) { continue; }

            Enemy enemy = enemyToDestroy.GetComponent<Enemy>();
            if (enemy.IsEnemyEnabled)
            {
                enemy.PlayDestroyEffect(true);
                destroyedEnemies++;
                if (effectOnDestroy != null) { yield return effectOnDestroy.UseItem(player, audioSource); };
            }
        }

        audioSource.PlayOneShot(thunderClip);

        yield break;
    }
}
