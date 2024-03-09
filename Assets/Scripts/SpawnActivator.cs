using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnActivator : MonoBehaviour
{
    [SerializeField]
    GameObject spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ship"))
        {
            Debug.Log("Collision with Ship.");
            if(spawner != null)
            spawner.SetActive(true);
        }
    }
}
