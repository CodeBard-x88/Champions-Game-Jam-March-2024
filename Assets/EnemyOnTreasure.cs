using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnTreasure : MonoBehaviour
{

    public GameObject gameOverCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameOverCanvas.SetActive(true);

            Time.timeScale = 0f;
        }
    }



}
