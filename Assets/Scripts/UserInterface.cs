using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] RectTransform healthBar = null;

    float sizePerHeart;
    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerStats.onHealthChange += UpdateHealthBar;

        sizePerHeart = healthBar.sizeDelta.x / playerStats.Health;
    }

    private void UpdateHealthBar()
    {
        Vector2 updatedSize = healthBar.sizeDelta;
        updatedSize.x = sizePerHeart * playerStats.Health;
        healthBar.sizeDelta = updatedSize;
    }
}
