using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitSound : MonoBehaviour
{
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy Bullet"))
        {
            sound = GetComponent<AudioSource>();
            sound.Play();

        }
    }
}
