using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerCarTransform;
    [SerializeField] float offSet = -5f;


    void Start()
    {
        
    }

    void Update()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.z = playerCarTransform.position.z + offSet;
        transform.position = cameraPos;

    }
}
