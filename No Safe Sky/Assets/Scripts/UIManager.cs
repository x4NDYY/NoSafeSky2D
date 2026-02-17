using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI killText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI healthText;

    GunController currentGun;

    private void Awake()
    {
        Instance = this;
    }
    public void SetGun(GunController gun)
    {
        currentGun = gun;
    }

    void Update()
    {

        if (currentGun != null)
        {
            ammoText.text =
                currentGun.GetCurrentAmmo() + " / " +
                currentGun.GetReserveAmmo();
        }
    }

    public void UpdateKillText(int current, int max)
    {
        killText.text = current + " / " + max;
    }

    public void UpdateMoneyText(int money)
    {
        moneyText.text = "" + money;
    }

    public void UpdateHealthText(float health)
    {
        healthText.text = "" + health;
    }
}
