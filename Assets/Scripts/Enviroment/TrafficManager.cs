using System.Collections;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{

    [SerializeField] Transform[] lane;
    [SerializeField] GameObject[] trafficVechile;


    void Start()
    {
        StartCoroutine(TrafficSpawner());
    }

    IEnumerator TrafficSpawner()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            int randomLaneIndex = Random.Range(0, lane.Length);
            int randomtrafficVechileIndex = Random.Range(0, trafficVechile.Length);

            Instantiate(trafficVechile[randomtrafficVechileIndex], lane[randomLaneIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
