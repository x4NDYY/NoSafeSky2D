using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    public GunController gun;

    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = gun.GetCurrentAmmo() + " / " + gun.GetReserveAmmo();
    }
}
