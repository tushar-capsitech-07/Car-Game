using UnityEngine;

public class FollowCar : MonoBehaviour
{
    [SerializeField] private Transform carTransform;
    [SerializeField] private Transform cameraPositiontransform;

    private float fixedY;

    void Start()
    {
        fixedY = transform.position.y;
    }

    void Update()
    {
        Vector3 newPosition = cameraPositiontransform.position;
        newPosition.y = fixedY;
        transform.position = newPosition;

        Vector3 lookAtPosition = new Vector3(carTransform.position.x, fixedY, carTransform.position.z);
        transform.LookAt(lookAtPosition);
    }
}