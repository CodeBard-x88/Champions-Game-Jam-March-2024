using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public List<Transform> spawnPoints; // List of spawn points
    public float respawnTime = 3f; // Time before respawning enemy

    private void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                // Check if the spawn point is free (no enemy spawned on it)
                Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 0.1f);
                bool isSpawnPointFree = true;
                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag("Enemy"))
                    {
                        isSpawnPointFree = false;
                        break;
                    }
                }

                // If spawn point is free, spawn a new enemy
                if (isSpawnPointFree)
                {
                    Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                }
            }

            yield return new WaitForSeconds(respawnTime);
        }
    }
}
