using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Drone : MonoBehaviour
{
    internal void Move(float speed)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);
    }
}
