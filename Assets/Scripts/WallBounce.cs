using UnityEngine;

public class WallBounce : MonoBehaviour
{
    private Rigidbody rb; // Assuming 2D physics for simplicity

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Get the normal of the collision
            Vector2 normal = collision.contacts[0].normal;

            // Reflect the velocity based on the wall's normal
            Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, normal);

            // Set the new velocity
            rb.velocity = reflectedVelocity;
        }
    }
}
