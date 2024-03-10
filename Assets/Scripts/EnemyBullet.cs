using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f; // Speed of the bullet

    public GameObject impactEffect; // Effect to show on impact
    public AudioClip destroySound; // Sound to play on bullet destruction

    private bool hasPlayedSound = false; // Flag to track whether the sound has been played

    private void Update()
    {
        if (target == null)
        {
            DestroyBullet();
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("BULLET HIT PLAYER");
            other.GetComponent<TakeDamage>().TakeDamageForPlayer(5);
            DestroyBullet();
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void HitTarget()
    {
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (!hasPlayedSound && destroySound != null)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
            hasPlayedSound = true;
        }
        Destroy(gameObject);
    }
}
