using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;

    public event Action onHealthChange;

    public int Health { get => maxHealth; }

    public void UpdateHealth(int modifier)
    {
        maxHealth = Mathf.Clamp(maxHealth + modifier, 0, maxHealth);
        if (onHealthChange != null) { onHealthChange(); }
    }
}
