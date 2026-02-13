using UnityEngine;

public class ShootHitScan : MonoBehaviour
{
    public LayerMask droneLayer;

    public void Shoot()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = mouse;

        Collider2D hit = Physics2D.OverlapPoint(pos, droneLayer);

        if (hit != null)
            hit.GetComponent<DroneMover>()?.Explode(true);
    }
}
