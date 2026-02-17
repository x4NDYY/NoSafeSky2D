using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 3f;
    public GameOverUI gameOverUI;
    float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        UIManager.Instance.UpdateHealthText(currentHealth);
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
            Die();

        UIManager.Instance.UpdateHealthText(currentHealth);
    }

    void Die()
    {
        gameOverUI.Show();
    }
}
