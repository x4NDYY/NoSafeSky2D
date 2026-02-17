using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject[] vehiclePrefab;

    void Start()
    {
        int index = GameManager.Instance.saveData.selectedVehicleIndex;

        GameObject vehicle = Instantiate(
        vehiclePrefab[index],
        transform.position,
        Quaternion.identity
    );

        // передаём GunController в UI
        GunController gun = vehicle.GetComponent<GunController>();

        Debug.Log("Gun found: " + gun);

        if (gun != null)
        {
            UIManager.Instance.SetGun(gun);
        }
    }
}
