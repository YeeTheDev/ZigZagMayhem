using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] RectTransform healthBar = null;
    [SerializeField] TextMeshProUGUI ammoIndicator = null;
    [SerializeField] string takeDamageParameter = "TakeDamage";
    [SerializeField] string gameOverParameter = "GameOver";

    float sizePerHeart;
    Shooter shooter;
    PlayerStats playerStats;
    BulletPooler bulletPooler;
    Animator animator;

    private void Awake()
    {
        shooter = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooter>();
        playerStats = shooter.GetComponent<PlayerStats>();
        bulletPooler = shooter.GetComponent<BulletPooler>();
        animator = GetComponent<Animator>();

        shooter.onShoot += RemoveFromBulletCounter;
        bulletPooler.onReload += AddToBulletCounter;
        playerStats.onHealthChange += UpdateHealthBar;
        playerStats.onDead += GameOverAnimation;

        sizePerHeart = healthBar.sizeDelta.x / playerStats.MaxHealth;
    }

    private void UpdateHealthBar(bool takeDamage)
    {
        if (takeDamage) { animator.SetTrigger(takeDamageParameter); }

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

    private void GameOverAnimation() { animator.SetTrigger(gameOverParameter); }
}
