using UnityEngine;
using System.Collections;

public class GunTracer : MonoBehaviour
{
    public LineRenderer tracerPrefab;
    public Transform firePoint;

    public float bulletSpeed = 100f;   // скорость полёта
    public float lifeTime = 0.05f;    // сколько живёт после долёта

    public void Shoot()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;

        LineRenderer tracer = Instantiate(tracerPrefab);

        StartCoroutine(AnimateTracer(tracer, firePoint.position, mouse));
    }

    IEnumerator AnimateTracer(LineRenderer tracer, Vector3 start, Vector3 end)
    {
        tracer.useWorldSpace = true;

        float distance = Vector3.Distance(start, end);
        Vector3 dir = (end - start).normalized;

        float traveled = 0;
        float tracerLength = 0.5f; // длина самой полоски

        while (traveled < distance + tracerLength)
        {
            traveled += bulletSpeed * Time.deltaTime;

            Vector3 head = start + dir * traveled;
            Vector3 tail = head - dir * tracerLength;

            tracer.SetPosition(0, tail);
            tracer.SetPosition(1, head);

            yield return null;
        }

        Destroy(tracer.gameObject);
    }
}
