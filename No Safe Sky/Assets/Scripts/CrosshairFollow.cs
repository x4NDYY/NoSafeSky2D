using UnityEngine;

public class CrosshairFollow : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (GameManager.IsGameOver)
            return;

        Cursor.visible = false;
        transform.position = Input.mousePosition;
    }

}
