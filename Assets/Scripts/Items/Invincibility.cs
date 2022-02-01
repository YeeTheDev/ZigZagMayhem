using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour, IITem
{
    [SerializeField] float invincibilityTime = 10f;
    [SerializeField] Color invincibilityColor = Color.blue;

    public IEnumerator UseItem(Transform t = null)
    {
        TankCollisioner tankCollisioner = GameObject.FindGameObjectWithTag("Player").GetComponent<TankCollisioner>();
        tankCollisioner.SetInvincibility(invincibilityTime, invincibilityColor);

        yield break;
    }
}
