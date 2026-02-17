using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI killText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI ammoText;

    GunController currentGun;

    private void Awake()
    {
        Instance = this;
    }
    public void SetGun(GunController gun)
    {
        Debug.Log("SetGun called");
        currentGun = gun;
    }

    void Update()
    {
        Debug.Log("UI Update running");

        if (currentGun != null)
        {
            ammoText.text =
                currentGun.GetCurrentAmmo() + " / " +
                currentGun.GetReserveAmmo();
        }
    }

    public void UpdateKillText(int current, int max)
    {
        killText.text = "Сбито: " + current + " / " + max;
    }

    public void UpdateMoneyText(int money)
    {
        Debug.Log("Updating money text: " + money);
        moneyText.text = "Заработано: " + money;
    }
}
