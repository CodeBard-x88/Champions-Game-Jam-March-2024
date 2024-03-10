using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float SmoothRotationTime = 0.25f;
    public bool MobileController = false;
    public FixedJoystick joystick;

    float currentVelocity;
    float currentSpeed;
    float speedVelocity;

    Rigidbody rb;
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float fireRate = 5f; // Bullets fired per second
    private float nextFireTime; // Time of the next allowed bullet fire
    [SerializeField] private LayerMask aimColliderMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform bulletProjectile;

    Transform cameraTransform;

    public AudioSource shootSound;
    public bool isShooting = false;

    public GameObject backGun;
    public GameObject fireGun;





    void Start()
    {
        cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        nextFireTime = Time.time; // Set the initial next fire time


    }
  
    void ShootingBullets()
    {

        GetComponent<AnimationScript>().PlayFireAnimation();

        if (Time.time >= nextFireTime)
        {
            // Calculate direction from gunTransform to debugTransform
            Vector3 direction = (debugTransform.position - gunTransform.position).normalized;

            // Instantiate the bullet prefab
            GameObject bulletObject = Instantiate(bulletPrefab, gunTransform.position, Quaternion.LookRotation(direction));

            // Apply force to the bullet in the calculated direction
            Rigidbody bulletRigidbody = bulletObject.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(direction * 20f, ForceMode.Impulse);

            // Set the next fire time based on the fire rate
            nextFireTime = Time.time + 1f / fireRate;

            Destroy(bulletObject, 1f);

        }


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
        else
        {

            GetComponent<AnimationScript>().PlayStandAnimation();
            if (fireGun != null)
            {
                fireGun.SetActive(false);
            }
        }


        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);


        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        LayerMask layerMask = ~LayerMask.GetMask("Player");
        if (Physics.Raycast(ray, out RaycastHit raycasthit, 999f, aimColliderMask))
        {

            debugTransform.position = raycasthit.point;
            mouseWorldPosition = raycasthit.point;

        }



        if (isShooting)
        {

            if(fireGun!=null)
            { fireGun.SetActive(true); }

            if (backGun != null){
            
                backGun.SetActive(false);
            }

            if (!shootSound.isPlaying)
            {
                shootSound.Play();
            }

            ShootingBullets();


            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);



            Vector3 aimDir = (mouseWorldPosition - gunTransform.position).normalized;
            //  Instantiate(bulletProjectile, gunTransform.position, Quaternion.LookRotation(aimDir, Vector3.up));

        }
        else{

            shootSound.Stop();
            if (fireGun != null)
                fireGun.SetActive(false);
            if (backGun != null)
                backGun.SetActive(true);
        }
        
    }
}
