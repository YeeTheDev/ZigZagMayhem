using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] RectTransform healthBar = null;
    [SerializeField] TextMeshProUGUI ammoIndicator = null;

    float sizePerHeart;
    Shooter shooter;
    PlayerStats playerStats;
    BulletPooler bulletPooler;

    private void Awake()
    {
        shooter = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooter>();
        playerStats = shooter.GetComponent<PlayerStats>();
        bulletPooler = shooter.GetComponent<BulletPooler>();

        shooter.onShoot += RemoveFromBulletCounter;
        bulletPooler.onReload += AddToBulletCounter;
        playerStats.onHealthChange += UpdateHealthBar;

        sizePerHeart = healthBar.sizeDelta.x / playerStats.MaxHealth;
    }

    private void UpdateHealthBar()
    {
        Vector2 updatedSize = healthBar.sizeDelta;
        updatedSize.x = sizePerHeart * playerStats.Health;
        healthBar.sizeDelta = updatedSize;
    }

    private void AddToBulletCounter() { UpdateBulletCounter(true); }
    private void RemoveFromBulletCounter() { UpdateBulletCounter(false); }

    private void UpdateBulletCounter(bool addAmmo)
    {
        ammoIndicator.text = addAmmo ? ammoIndicator.text + "|" : ammoIndicator.text.Remove(ammoIndicator.text.Length - 1);
    }
}
