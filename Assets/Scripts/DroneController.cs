using UnityEngine;

public class DroneController : MonoBehaviour
{
    private Drone drone;
    public float speed = 2f;
    public float moveSpeed = 1f;
    public Vector2 turn;
    Rigidbody rb;
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float fireRate = 5f; // Bullets fired per second
    private float nextFireTime; // Time of the next allowed bullet fire
    bool isColliding = false;

    void Start()
    {
        drone = GetComponent<Drone>();
        rb = GetComponent<Rigidbody>();
        nextFireTime = Time.time; // Set the initial next fire time
    }

    void ShootingBullets()
    {
        // Check if it's time to fire another bullet
        if (Time.time >= nextFireTime)
        {
            // Instantiate the bullet prefab
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);

            // Set the next fire time based on the fire rate
            nextFireTime = Time.time + 1f / fireRate;

            // Destroy the bullet after 1 second
            Destroy(bullet, 1f);
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement direction to the drone's Rigidbody with constant velocity
        rb.velocity = transform.forward * moveSpeed;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            drone.Move(speed);
        }

        if (Input.GetKey(KeyCode.Q))
            ShootingBullets();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is from the front
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, transform.forward) < -0.5f)
            {
                isColliding = true;
                rb.velocity = Vector3.zero; // Stop movement in the colliding direction
                break;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Reset collision flag when no longer colliding
        isColliding = false;
    }
}
