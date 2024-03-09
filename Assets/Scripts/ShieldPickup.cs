using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    public float invincibilityDuration = 10f; // Duration of invincibility after picking up the shield
    public HealthBarScript healthBar; // Reference to the HealthBarScript assigned in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (healthBar != null)
            {
                // Activate invincibility on the player
                healthBar.ActivateInvincibility(invincibilityDuration);

                // Destroy the shield pickup GameObject
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("HealthBarScript reference is not assigned! Make sure to assign the HealthBarScript in the Inspector.");
            }
        }
    }
}
