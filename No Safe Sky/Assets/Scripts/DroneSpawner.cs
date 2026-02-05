using UnityEngine;
using System.Collections;

public class DroneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dronePrefab;
    [SerializeField] private Transform waypointParent;

    [SerializeField] private float minDelay = 2f;
    [SerializeField] private float maxDelay = 7f;

    Transform[] points;

    void Start()
    {
        // собираем точки автоматически
        points = new Transform[waypointParent.childCount];

        for (int i = 0; i < points.Length; i++)
            points[i] = waypointParent.GetChild(i);

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnDrone();

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnDrone()
    {
        GameObject drone = Instantiate(dronePrefab, points[0].position, Quaternion.identity);

        DroneMover mover = drone.GetComponent<DroneMover>();
        mover.waypoints = points;
    }
}
