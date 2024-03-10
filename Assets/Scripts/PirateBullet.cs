using UnityEngine;

public class PirateBullet : MonoBehaviour
{
    public float speed = 10f; 
    public float distance = 10f; 

    private Vector3 initialPosition; // Initial position of the bullet

    void Start()
    {
        initialPosition = GameObject.FindGameObjectWithTag("enemyfirepoint").transform.position;
    }

    void Update()
    {
        // Move the bullet forward based on its speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Calculate the distance traveled by the bullet
        float traveledDistance = Vector3.Distance(transform.position, initialPosition);

        // Check if the bullet has traveled the defined distance
        if (traveledDistance >= distance)
        {
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
