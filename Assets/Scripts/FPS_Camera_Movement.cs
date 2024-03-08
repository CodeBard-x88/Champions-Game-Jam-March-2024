using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera_Movement : MonoBehaviour
{
    [SerializeField]
    private Camera MainFPSCamera;
    [SerializeField]
    private float mouse_Sensitivity = 10f;
    [SerializeField]
    private float minVerticalMovement;
    [SerializeField]
    private float maxVerticalMovement;

    private float yAxis;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //locks the cursor on the screen
    }
    void UpdateCameraRotation()
    {
        float horizontalMovement = Input.GetAxis("Mouse X") * mouse_Sensitivity;
        float verticalMovement = Input.GetAxis("Mouse Y") * mouse_Sensitivity;

        this.transform.Rotate(Vector3.up * horizontalMovement);  //horizontal player Movement on moving mouse left or right

        yAxis -= verticalMovement;
        yAxis = Mathf.Clamp(yAxis, minVerticalMovement,maxVerticalMovement);
        MainFPSCamera.transform.localRotation = Quaternion.Euler(yAxis, 0f, 0f); //vertical movement of camera on moving mouse up or down.
    }
    void Update()
    {
        UpdateCameraRotation();
    }
}
