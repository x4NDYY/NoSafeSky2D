using UnityEngine;

public class PlaneSoundTrigger : MonoBehaviour
{
    public float triggerX = -15f;

    private AudioSource audioSource;
    private float lastX;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

        lastX = transform.position.x;
    }

    void Update()
    {
        float x = transform.position.x;

        // пересекли границу справа → налево
        if (lastX > triggerX && x <= triggerX)
        {
            audioSource.Stop();
            audioSource.Play();
        }

        lastX = x;
    }
}
