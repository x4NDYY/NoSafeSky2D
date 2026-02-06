using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth player;
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "HP: " + player.GetHealth();
    }
}
