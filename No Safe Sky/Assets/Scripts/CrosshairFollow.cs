using UnityEngine;

public class CrosshairFollow : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false; // прячем стандартную стрелку
    }

    void Update()
    {
        transform.position = Input.mousePosition; // прицел следует за мышью
    }
}
