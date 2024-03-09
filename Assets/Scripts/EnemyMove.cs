using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints; // List of empty GameObjects (waypoints)
    public float speed = 5f; // Speed of movement

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool movingForward = true; // Flag to track movement direction

    void Update()
    {
        // Check if there are waypoints to follow
        if (waypoints.Count > 0)
        {
            // Calculate direction to the current waypoint
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.Normalize();

            // Move towards the current waypoint
            transform.Translate(direction * speed * Time.deltaTime);

            // Check if the enemy has reached the current waypoint
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                // Move to the next waypoint or the previous one if moving in reverse
                if (movingForward)
                {
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
                }
                else
                {
                    currentWaypointIndex = (currentWaypointIndex - 1 + waypoints.Count) % waypoints.Count;
                }

                // Check if the enemy has reached the end or beginning of the waypoints list
                if (currentWaypointIndex == 0 || currentWaypointIndex == waypoints.Count - 1)
                {
                    // Toggle the movement direction
                    movingForward = !movingForward;
                }
            }
        }
    }
}
