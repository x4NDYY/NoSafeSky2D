using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    Vector3 startPos;

    void Awake()
    {
        instance = this;
        startPos = transform.localPosition;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        float time = 0;

        while (time < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = startPos + new Vector3(x, y, 0);

            time += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localPosition = startPos;
    }
}
