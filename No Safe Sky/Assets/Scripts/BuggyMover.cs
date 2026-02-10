using Unity.VisualScripting;
using UnityEngine;

public class BuggyMover : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;

    private int current = 0;

    private void Update()
    {
        if(target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position, 
            target.position, 
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
                Destroy(gameObject);
        }
    }
}
