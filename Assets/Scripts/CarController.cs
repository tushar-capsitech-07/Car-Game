using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Input Settings")]
    private float horizontalInput;
    private float verticalInput;

    [Header("Car Settings")]
    [SerializeField] private float motorForce = 100f;
    [SerializeField] private float brakeForce = 100000f;
    [SerializeField] private float maxSteerAngle = 30f;

    [Header("Wheel Transforms")]
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;

    [Header("Wheel Colliders")]
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;


    // -------------------------------------------------------------------------------------------------------------------------------------------------


    private void Update()
    {
        CaptureInput();
    }

    private void FixedUpdate()
    {
        ApplyMotorTorque();
        ApplySteering();
        ApplyBraking();
        UpdateWheelVisuals();
        PowerSteering();
    }

    // ---------------------- Input ----------------------

    private void CaptureInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    // ---------------------- Movement ----------------------

    private void ApplyMotorTorque()
    {
        float torque = motorForce * verticalInput;

        frontRightWheelCollider.motorTorque = torque;
        frontLeftWheelCollider.motorTorque = torque;
        rearRightWheelCollider.motorTorque = torque;
        rearLeftWheelCollider.motorTorque = torque;
    }
    private void ApplySteering()
    {
        float steerAngle = maxSteerAngle * horizontalInput;

        frontRightWheelCollider.steerAngle = steerAngle;
        frontLeftWheelCollider.steerAngle = steerAngle;
    }
    void PowerSteering()
    {
        if(horizontalInput == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime);
        }
    }
    private void ApplyBraking()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            frontRightWheelCollider.brakeTorque = brakeForce;
            frontLeftWheelCollider.brakeTorque = brakeForce;
            rearRightWheelCollider.brakeTorque = brakeForce;
            rearLeftWheelCollider.brakeTorque = brakeForce;
        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0f;
            frontLeftWheelCollider.brakeTorque = 0f;
            rearRightWheelCollider.brakeTorque = 0f;
            rearLeftWheelCollider.brakeTorque = 0f;
        }
    }
    // ---------------------- Wheel Visuals ----------------------

    private void UpdateWheelVisuals()
    {
        UpdateWheelPose(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPose(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPose(rearRightWheelCollider, rearRightWheelTransform);
        UpdateWheelPose(rearLeftWheelCollider, rearLeftWheelTransform);
    }
    private void UpdateWheelPose(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }

}