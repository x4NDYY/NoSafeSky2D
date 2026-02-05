using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public float speed = 5f;
    public float segmentWidth = 20.48f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -segmentWidth)
        {
            transform.position += Vector3.right * segmentWidth * 2f;
        }
    }
}
