using UnityEngine;

public class OtherObstacles : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed *  Time.deltaTime);
    }


}
