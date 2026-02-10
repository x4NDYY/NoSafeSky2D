using UnityEngine;

public class DroneCollisionExplode : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;

        Explode();
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
