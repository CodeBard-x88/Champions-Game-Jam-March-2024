using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float RotationSensitivity = 5f;
    public float DistanceFromTarget = 8f;
    public bool MobileController = false;
    public FixedJoystick joystick;

    float RotationMin = -40f;
    float RotationMax = 80f;
    float smoothTime = 0.12f;

    public Transform target;

    float Yaxis;
    float Xaxis;
    Vector3 currentVel;

    public FixedTouchField touchField;

    void LateUpdate()
    {
        if (MobileController)
        {
            Yaxis += touchField.TouchDist.x * RotationSensitivity;
            Xaxis += touchField.TouchDist.y * RotationSensitivity;
        }
        else
        {
            Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
            Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
        }
        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);

        Vector3 targetRotation = new Vector3(Xaxis, Yaxis);
        transform.eulerAngles = targetRotation;

        Vector3 newPosition = target.position - transform.forward * DistanceFromTarget;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVel, smoothTime);
    }
}
