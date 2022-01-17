using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] RectTransform healthBar = null;

    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerStats.onHealthChange += UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        
    }
}
