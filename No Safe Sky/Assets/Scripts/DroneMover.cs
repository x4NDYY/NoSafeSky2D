using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class DroneMover : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public GameObject explosionPrefab;

    private int current = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[current];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // достиг точки
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            current++;

            // последняя точка → взрыв и удаление
            if (current >= waypoints.Length)
            {
                PlayerHealth player = FindObjectOfType<PlayerHealth>();
                player.TakeDamage(0.5f);

                Explode();
            }
        }
    }

    public void Explode()
    {
        if (explosionPrefab)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        CameraShake.instance.Shake(0.12f, 0.18f);

        Destroy(gameObject);
    }
}
