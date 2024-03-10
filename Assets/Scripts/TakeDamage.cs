// In the PlayerHealth script

using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public HealthBarScript healthBar; // Reference to the health bar script
    public Canvas gameover;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamageForPlayer(int damage)
    {
        if (!healthBar.isInvincible)
        {
            if (currentHealth >= 0)
            {
                currentHealth -= damage;
            }
        
            healthBar.SetHealth(currentHealth);

             if (currentHealth <= 0)
            {
                 Die();
            }
    }
    }

    void Die()
    {
        Destroy(gameObject);
        gameover.enabled = true;
        Time.timeScale = 0f;

    }
}
