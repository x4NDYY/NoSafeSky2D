using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    public float speed = 600f;

    void Update()
    {
        transform.Rotate(0, 0, -speed *  Time.deltaTime);
    }
}
