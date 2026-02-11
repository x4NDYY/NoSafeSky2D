using UnityEngine;

public class DroneCollisionExplode : MonoBehaviour
{
    public GameObject explosionPrefab;
    public string nextSceneName = "MenuScene";
    public float delayBeforeLoad = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;

        Explode();
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        LoadManager.Instance.LoadSceneWithDelay(nextSceneName, delayBeforeLoad);
        Destroy(gameObject);
    }
}
