using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollisioner : MonoBehaviour
{
    public event Action<float> onBecomeInvincible; 

    [SerializeField] MeshRenderer tankBodyRenderer = null;
    [SerializeField] MeshRenderer tankHeadRenderer = null;

    float invincibleTimer;
    Color initialColor;
    Color invincibilityColor;

    Coroutine invincibleCoroutine;
    PlayerStats playerStats;
    AudioSource audioSource;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        initialColor = tankBodyRenderer.material.color;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            StartCoroutine(ActivateItem(other.transform));
        }

        if (other.CompareTag("Enemy"))
        {
            if (invincibleTimer > 0) { return; }

            playerStats.UpdateHealth(-1);
        }
    }

    private IEnumerator ActivateItem(Transform item)
    {
        List<IITem> itemSequence = item.GetComponent<ItemBuilder>().GetItemSequence();

        foreach (IITem itemToUse in itemSequence)
        {
            yield return itemToUse.UseItem(transform, audioSource);
        }

        Destroy(item.gameObject);
    }

    public void SetInvincibility(float invincibilityTime, Color invincibilityColor)
    {
        invincibleTimer += invincibilityTime;
        if (onBecomeInvincible != null) { onBecomeInvincible(invincibleTimer); }

        this.invincibilityColor = invincibilityColor;

        if (invincibleCoroutine == null) { invincibleCoroutine = StartCoroutine(Invincibility()); }
    }

    private IEnumerator Invincibility()
    {
        SetRenderersColor();

        while (invincibleTimer > 0)
        {
            invincibleTimer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        SetRenderersColor();
        invincibleCoroutine = null;
    }

    private void SetRenderersColor()
    {
        Color colorToUse = invincibleTimer > 0 ? invincibilityColor : initialColor;
        tankBodyRenderer.material.color = colorToUse;
        tankHeadRenderer.material.color = colorToUse;
    }
}
