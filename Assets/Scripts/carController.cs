using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeftWheelCollider;
    [SerializeField] WheelCollider frontRightWheelCollider;
    [SerializeField] WheelCollider rearLeftWheelCollider;
    [SerializeField] WheelCollider rearRightWheelCollider;

    [SerializeField] Transform frontLeftWheelTransform;
    [SerializeField] Transform frontRightWheelTransform;
    [SerializeField] Transform rearLeftWheelTransform;
    [SerializeField] Transform rearRightWheelTransform;


    public AudioManager AudioManager;
    /*    [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip bumpSound;*/




    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private bool isBraking;
    private float currentBrakeForce;
    public float rotationDamping;

    private float sidewaysESlip = 0.4f;
    private float sidewaysEValue = 1.0f;
    private float sidewaysASlip = 0.5f;
    private float sidewaysAValue = 0.75f;
    private float sidewaysStiffness = 1f;

    private float forwardESlip = 0.4f;
    private float forwardEValue = 1.0f;
    private float forwardASlip = 0.5f;
    private float forwardAValue = 0.75f;
    private float forwardStiffness = 1f;

    [SerializeField] private float brakeForce;
    [SerializeField] private float motorForce;
    [SerializeField] private float maxSteerAngle;

    public PlayerStats playerStats;
    public Rigidbody playerRB;
    public Vector3 centerOfMass;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        frontLeftWheelCollider.ConfigureVehicleSubsteps(1f, 5, 5);
        frontRightWheelCollider.ConfigureVehicleSubsteps(1f, 5, 5);
        rearLeftWheelCollider.ConfigureVehicleSubsteps(1f, 5, 5);
        rearRightWheelCollider.ConfigureVehicleSubsteps(1f, 5, 5);
        playerRB = GetComponent<Rigidbody>();
        playerRB.centerOfMass = centerOfMass;
        AudioManager = FindObjectOfType<AudioManager>();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        UpdateRotation();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBraking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        float torqueToApply = verticalInput * motorForce * playerStats.GetPlayerSpeedMultiplier();


        frontLeftWheelCollider.motorTorque = torqueToApply;
        frontRightWheelCollider.motorTorque = torqueToApply;
        ApplyBraking();
        HandleMotorSound();
        HandleBrakingSound();

    }

    private void ApplyBraking()
    {
        currentBrakeForce = isBraking ? brakeForce : 0f;
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
        rearLeftWheelCollider.steerAngle = -currentSteerAngle;
        rearRightWheelCollider.steerAngle = -currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;

        if (horizontalInput <= Mathf.Epsilon)
        {
            wheelCollider.wheelDampingRate = 15f;
        }
        if (verticalInput <= Mathf.Epsilon)
        {
            wheelCollider.wheelDampingRate = 15f;
        }

    }

    private void UpdateRotation()
    {
        Quaternion newRotation = gameObject.transform.localRotation;
        newRotation.z = 0;
        transform.rotation = Quaternion.Lerp(
            newRotation,
            Quaternion.LookRotation(gameObject.transform.forward),
            Time.deltaTime * rotationDamping
            );
    }


    // Playing a Bump sound in collider 
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is strong enough (optional, you can define a minimum force)
        if (collision.relativeVelocity.magnitude > 2)
        {
            // Play the bump sound
            AudioManager.PlayBumpSound();
        }
    }

    public void setMotorForce(float newMotorForce)
    {
        motorForce = newMotorForce;
    }
    public void setBrakeForce(float newBrakeForce)
    {
        brakeForce = newBrakeForce;
    }
    public void setSteeringAngle(float newSteeringAngle)
    {
        maxSteerAngle = newSteeringAngle;
    }

    private void HandleMotorSound() 
    { 
        if (verticalInput < 0 && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            AudioManager.StopEngineSound();
            AudioManager.StartReverseSound(); // Play the reverse sound when the down arrow key is pressed
        } 
        else if (verticalInput > 0 && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            AudioManager.StopReverseSound();
            AudioManager.StartEngineSound();
        }
        else
        {
            AudioManager.StopEngineSound();
            AudioManager.StopReverseSound();
        }
    }

    private void HandleBrakingSound()
    {
        if(isBraking && (Input.GetKey(KeyCode.Space)))
        {
            AudioManager.StartBrakingSound();
        } else
        {
            AudioManager.StopBrakingSound();
        }
    }
}
