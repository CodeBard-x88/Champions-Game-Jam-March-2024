using UnityEngine;

public class PotionPickup : MonoBehaviour
{
    public AudioSource sound;
    public PotionManager potionManager; // Reference to the PotionManager script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            potionManager.IncrementPotionCount(); // Increment potion count using PotionManager
        }
    }

  
}
