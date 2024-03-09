using UnityEngine;

public class HealthDecreaseOverTime : MonoBehaviour
{
    public HealthBarScript healthBar; // Reference to the HealthBarScript
    public float decreaseInterval = 1f; // Interval between health decreases
    public int decreaseAmount = 1; // Amount of health to decrease each interval

    private float timer; // Timer to track the interval

    void Start()
    {
        timer = decreaseInterval; // Start the timer
    }

    void Update()
    {
        // Decrement the timer
        timer -= Time.deltaTime;

        // If the timer reaches zero or below, decrease the health
        if (timer <= 0f)
        {
            DecreaseHealth();
            timer = decreaseInterval; // Reset the timer
        }
    }

    void DecreaseHealth()
    {
        // Decrease the player's health using the HealthBarScript
        healthBar.SetHealth(healthBar.GetHealth() - decreaseAmount);
    }
}
