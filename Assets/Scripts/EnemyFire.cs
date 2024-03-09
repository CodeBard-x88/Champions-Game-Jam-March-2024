using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f; // Shooting range of the enemy
    public float shootingCooldown = 1f; // Cooldown between shots

    [Header("Unity Setup Fields")]
    public Transform playerTransform; // Transform of the player GameObject
    public Transform firePoint; // Point from which bullets are fired
    public GameObject bulletPrefab; // Prefab of the bullet GameObject

    private float nextShootTime; // Time when the enemy can shoot again

    private void Update()
    {
        // If the player exists and is within range, and the enemy can shoot, shoot at them
        if (playerTransform != null && IsPlayerInRange() && Time.time >= nextShootTime)
        {
            Shoot(playerTransform);
            nextShootTime = Time.time + shootingCooldown; // Set next shoot time based on cooldown
        }
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        return distanceToPlayer <= range; // Return true if player is within shooting range, false otherwise
    }

    private void Shoot(Transform target)
    {
        // Instantiate bullet at the fire point position and rotation
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the bullet script component from the bullet GameObject
        EnemyBullet bullet = bulletGameObject.GetComponent<EnemyBullet>();

        // If the bullet script component is found, set its target
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a wire sphere in the Unity Editor to visualize the shooting range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
