using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private int total_Waves;

    [System.Serializable]
    public struct Waves {
        public int waveNumber;
        public int total_Enemies; }

    [SerializeField]
    public Waves[] waves;
    private int current_Wave;

    private void Start()
    {
        current_Wave = 0;
    }

    private void Update()
    {
        if (current_Wave < waves.Length)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                int i = 0, count = 0;
                for (; count < waves[current_Wave].total_Enemies; i++)
                {
                    GameObject enemy = Instantiate(enemyPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.localRotation);
                    i++;
                    count++;
                    if (i >= spawnPoints.Length) i = 0;
                }
                current_Wave++;
            }
        }
    }



}
