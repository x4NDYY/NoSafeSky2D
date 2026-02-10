using UnityEngine;
using System.Collections;

public class AudioFadeByDistance : MonoBehaviour
{
    public Transform listener;
    public float maxDistance = 20f;

    [Range(0f, 1f)]
    public float maxVolume = 0.3f;

    public float fadeSpeed = 6f;

    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0;
        source.Play();
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, listener.position);

        bool inRange = dist < maxDistance;

        if (inRange && !source.isPlaying)
            source.Play();

        float target = inRange ? maxVolume : 0f;


        source.volume = Mathf.Lerp(source.volume, target, fadeSpeed * Time.deltaTime);

        if (!inRange && source.volume < 0.01f)
            source.Stop();
    }
}
