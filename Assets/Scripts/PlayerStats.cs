using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action<bool> onHealthChange;
    public event Action onDead;

    [SerializeField] int maxHealth = 3;
    [SerializeField] ParticleSystem smoke = null;
    [SerializeField] AudioClip explosionClip = null;

    public int MaxHealth { get => maxHealth; }

    public int Health { get; set; }

    private void Awake() { Health = maxHealth; }

    public void UpdateHealth(int modifier)
    {
        Health = Mathf.Clamp(Health + modifier, 0, maxHealth);
        if (onHealthChange != null) { onHealthChange(modifier < 0); }
        if (Health <= 0) { PlayDeadSequence(); }
    }

    public void PlayDeadSequence()
    {
        if (onDead != null) { onDead(); }
        smoke.Play();
        GetComponent<AudioSource>().PlayOneShot(explosionClip);
    }
}
