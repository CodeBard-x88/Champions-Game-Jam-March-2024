using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    LayerMask whatisGround, whatisPlayer;
    [SerializeField]
    private float timebetweenAttacks;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float health;
    
    private Transform treasure;
    private bool alreadyAttacked, playerinAttackRnage;
    private Transform player;
    private Animator animator;
    private  void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        treasure = GameObject.FindGameObjectWithTag("Treasure").transform;
        animator = GetComponent<Animator>();
    }
    
    private void MovetoTreasure()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isFiring", false);

        agent.SetDestination(treasure.position);
    }

    void AttackPlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
        animator.SetBool("isRunning", false);
        animator.SetBool("isFiring", true);
        agent.speed = Random.Range(minSpeed, maxSpeed);
        Debug.Log("Attacking Player");
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timebetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void Update()
    {
        if(health == 0)
        {
            animator.SetBool("isDying", true);
            Destroy(gameObject);
        }

        playerinAttackRnage = Physics.CheckSphere(transform.position, attackRange, whatisPlayer);

        if (playerinAttackRnage) AttackPlayer();
        else
        {
            MovetoTreasure();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
