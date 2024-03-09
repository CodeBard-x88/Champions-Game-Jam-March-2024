using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public int damageAmount = 20; 
    public GameObject impactEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);

            Instantiate(impactEffect, transform.position, Quaternion.identity);

            TakeDamage takeDamageScript = GetComponent<TakeDamage>();
            if (takeDamageScript != null)
            {
                takeDamageScript.TakeDamageForPlayer(damageAmount);
            }
        }
    }
}
