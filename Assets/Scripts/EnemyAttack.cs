using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    private Transform treasure;
    private Animator animator;

    public float range = 15f;
    public float shootingCooldown = 1f;
    private float nextShootTime;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        treasure = GameObject.FindGameObjectWithTag("Treasure").transform;
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("PlayerPos").transform; // Assuming player is tagged as "Player"
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            if (IsPlayerInRange() && Time.time >= nextShootTime)
            {
                Shoot(playerTransform);
                nextShootTime = Time.time + shootingCooldown;
            }
            else
            {
                MovetoTreasure();
            }
        }
    }

    private void MovetoTreasure()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isFiring", false);
        agent.SetDestination(treasure.position);
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        return distanceToPlayer <= range;
    }

    private void Shoot(Transform target)
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        EnemyBullet bullet = bulletGameObject.GetComponent<EnemyBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }

        agent.SetDestination(transform.position); // Stop movement while shooting
        transform.LookAt(target);
        animator.SetBool("isRunning", false);
        animator.SetBool("isFiring", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
