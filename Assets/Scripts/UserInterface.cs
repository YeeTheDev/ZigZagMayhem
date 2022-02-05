using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] RectTransform healthBar = null;
    [SerializeField] Text timerText = null;
    [SerializeField] TextMeshProUGUI ammoIndicator = null;
    [SerializeField] string takeDamageParameter = "TakeDamage";
    [SerializeField] string gameOverParameter = "GameOver";
    [SerializeField] string invincibilityParameter = "Invulnerability";
    [SerializeField] string invincibilitySpeedParameter = "InvicibilitySpeed";

    bool gameOver;
    float timer;
    float sizePerHeart;
    Shooter shooter;
    PlayerStats playerStats;
    TankCollisioner tankCollisioner;
    BulletPooler bulletPooler;
    Animator animator;

    private void Awake()
    {
        shooter = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooter>();
        playerStats = shooter.GetComponent<PlayerStats>();
        bulletPooler = shooter.GetComponent<BulletPooler>();
        animator = GetComponent<Animator>();
        tankCollisioner = shooter.GetComponent<TankCollisioner>();

        shooter.onShoot += RemoveFromBulletCounter;
        bulletPooler.onReload += AddToBulletCounter;
        playerStats.onHealthChange += UpdateHealthBar;
        playerStats.onDead += GameOverAnimation;
        tankCollisioner.onBecomeInvincible += PlayInvincibilityAnimation;

        sizePerHeart = healthBar.sizeDelta.x / playerStats.MaxHealth;
    }

    private void Update()
    {
        DisplayTimer();
    }

    private void DisplayTimer()
    {
        if (gameOver) { return; }

        timer += Time.deltaTime;
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = $"Time   {minutes:00}:{seconds:00}";
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

    private void GameOverAnimation()
    {
        gameOver = true;
        animator.SetTrigger(gameOverParameter);
    }

    private void PlayInvincibilityAnimation(float timeToPlay)
    {
        animator.SetFloat(invincibilitySpeedParameter, 1 / timeToPlay);
        animator.SetTrigger(invincibilityParameter);
    }
}
