using UnityEngine;

public class DestroyOnContactOfPlayerBullet : MonoBehaviour
{
    public int damageAmount = 20; // Amount of damage to apply to the player
    public GameObject impactEffect; // Effect to show on impact

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(other.gameObject);

            // Instantiate impact effect
            Instantiate(impactEffect, transform.position, Quaternion.identity);

            // Decrease player health
            //TakeDamage takeDamageScript = GetComponent<TakeDamage>();
            //if (takeDamageScript != null)
            //{
            //    takeDamageScript.TakeDamageForPlayer(damageAmount);
            //}
        }
    }
}
