using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float RotationSensitivity = 5f;
    public bool MobileController = false;
    public FixedJoystick joystick;

    public Vector2 RotationLimits = new Vector2(-40f, 80f);
    public float DistanceFromTarget = 8f;
    public Vector3 CameraOffset = new Vector3(0f, 0f, 0f);

    private float currentYaxis;
    private float currentXaxis;
    private Vector3 currentVel;

    public Transform target;
    public FixedTouchField touchField;

    void LateUpdate()
    {
        if (MobileController)
        {
            currentYaxis += touchField.TouchDist.x * RotationSensitivity;
            currentXaxis -= touchField.TouchDist.y * RotationSensitivity;
        }
        else
        {
            currentYaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
            currentXaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
        }
        currentXaxis = Mathf.Clamp(currentXaxis, RotationLimits.x, RotationLimits.y);

        Vector3 targetRotation = new Vector3(currentXaxis, currentYaxis);
        transform.eulerAngles = targetRotation;

        Vector3 newPosition = target.position - transform.forward * DistanceFromTarget + CameraOffset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVel, Time.deltaTime);
    }
}
