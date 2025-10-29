using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Input Settings")]
    private float horizontalInput;
    private float verticalInput;
    private bool isBraking;

    [Header("Car Settings")]
    [SerializeField] private float motorForce = 1500f;
    [SerializeField] private float brakeForce = 3000f;
    [SerializeField] private float maxSteerAngle = 30f;

    [Header("Wheel Colliders")]
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;

    [Header("Wheel Transforms")]
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        ApplyBrakes();
        UpdateWheelVisuals();
    }

    private void HandleMotor()
    {
        float torque = motorForce * verticalInput;
        frontLeftWheelCollider.motorTorque = torque;
        frontRightWheelCollider.motorTorque = torque;
        rearLeftWheelCollider.motorTorque = torque;
        rearRightWheelCollider.motorTorque = torque;
    }

    private void HandleSteering()
    {
        float steerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void ApplyBrakes()
    {
        float brakeTorque = isBraking ? brakeForce : 0f;
        frontLeftWheelCollider.brakeTorque = brakeTorque;
        frontRightWheelCollider.brakeTorque = brakeTorque;
        rearLeftWheelCollider.brakeTorque = brakeTorque;
        rearRightWheelCollider.brakeTorque = brakeTorque;
    }

    private void UpdateWheelVisuals()
    {
        UpdateWheelPose(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPose(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPose(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPose(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }

    // ----------------- Button Events -----------------
    public void OnAccelerateDown()
    {
        verticalInput = 1f;
        Debug.Log("Accelerate Down");
    }

    public void OnAccelerateUp()
    {
        verticalInput = 0f;
        Debug.Log("Accelerate Up");
    }

    public void OnBrakeDown()
    {
        isBraking = true;
        Debug.Log("Brake Down");
    }

    public void OnBrakeUp()
    {
        isBraking = false;
        Debug.Log("Brake Up");
    }

    public void OnLeftDown()
    {
        horizontalInput = -1f;
        Debug.Log("Left Down");
    }

    public void OnLeftUp()
    {
        horizontalInput = 0f;
        Debug.Log("Left Up");
    }

    public void OnRightDown()
    {
        horizontalInput = 1f;
        Debug.Log("Right Down");
    }

    public void OnRightUp()
    {
        horizontalInput = 0f;
        Debug.Log("Right Up");
    }
}
