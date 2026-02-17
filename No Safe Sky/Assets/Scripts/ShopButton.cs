using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public int vehicleIndex;
    public int price;

    [SerializeField] private TextMeshProUGUI buttonText;

    public void Start()
    {
        UpdateText();
    }

    public void OnClick()
    {
        var data = SaveSystem.Load();

        if (!data.purchasedVehicles[vehicleIndex])
        {
            if(data.money < price)
            {
                Debug.Log("Not enough money");
                return;
            }

            data.money -= price;
            data.purchasedVehicles[vehicleIndex] = true;
        }

        data.selectedVehicleIndex = vehicleIndex;
        SaveSystem.Save(data);
        RefreshAllButtons();
    }

    void RefreshAllButtons()
    {
        ShopButton[] buttons = FindObjectsOfType<ShopButton>();
        foreach (var btn in buttons)
        {
            btn.UpdateText();
        }
    }

    public void UpdateText()
    {
        var data = SaveSystem.Load();

        if (!data.purchasedVehicles[vehicleIndex])
        {
            buttonText.text = "$" + price;
        }
        else
        {
            if (data.selectedVehicleIndex == vehicleIndex)
                buttonText.text = "Выбрано";
            else
                buttonText.text = "Куплено";
        }
    }
}
