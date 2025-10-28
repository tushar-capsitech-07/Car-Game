using UnityEngine;

public class EndlessCity : MonoBehaviour
{

    [SerializeField] Transform PlayerCarTransform;
    [SerializeField] Transform OtherCityTransform;
    [SerializeField] float halfLength;

    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerCarTransform.position.z > transform.position.z + halfLength + 10f)
        {
            transform.position = new Vector3(0, 0, OtherCityTransform.position.z + halfLength * 2);
        }
    }
}
