using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public int vehicleIndex;
    public int price;

    public void Buy()
    {
        var data = GameManager.Instance.saveData;

        if (data.money >= price && !data.purchasedVehicles[vehicleIndex])
        {
            data.money -= price;
            data.purchasedVehicles[vehicleIndex] = true;
            data.selectedVehicleIndex = vehicleIndex;

            SaveSystem.Save(data);

            Debug.Log("Vehicle purchased!");
        }
        else
            Debug.Log("Not enough money or already purchased");
    }

    public void Select(int index)
    {
        var data = GameManager.Instance.saveData;

        if (data.purchasedVehicles[index])
        {
            data.selectedVehicleIndex = index;
            SaveSystem.Save(data);
        }
    }
}
