using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletForce = 4000f;
    public AudioSource gunsound;

    private void Awake()
    {
        gunsound = GetComponent<AudioSource>();
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletForce);
        gunsound.Play();
    }
}
