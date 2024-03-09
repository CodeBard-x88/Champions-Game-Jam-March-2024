using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float SmoothRotationTime = 0.25f;
    public bool MobileController = false;
    public FixedJoystick joystick;

    float currentVelocity;
    float currentSpeed;
    float speedVelocity;


    Transform cameraTransform;


    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    void Update()
    {

        Vector2 input = Vector2.zero;

        if (MobileController)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);

        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, SmoothRotationTime);
        }


        float TargetSpeed = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, TargetSpeed, ref speedVelocity, 0.1f);


        if (inputDir.magnitude > 0)
        {

            GetComponent<AnimationScript>().PlayRunAnimation();
        }
        else {

            GetComponent<AnimationScript>().PlayStandAnimation();
        }


        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
       

    }
}
