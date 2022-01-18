using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action onHealthChange;

    [SerializeField] int maxHealth = 3;
    public int MaxHealth { get => maxHealth; }

    public int Health { get; set; }

    private void Awake() { Health = maxHealth; }

    public void UpdateHealth(int modifier)
    {
        Health = Mathf.Clamp(Health + modifier, 0, maxHealth);
        if (onHealthChange != null) { onHealthChange(); }
    }
}
