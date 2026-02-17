using UnityEngine;
using System.IO;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/save.json";

    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public static SaveData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<SaveData>(json);
        }

        SaveData data = new SaveData();
        data.money = 0;
        data.selectedVehicleIndex = 0;
        data.purchasedVehicles = new bool[3];
        data.purchasedVehicles[0] = true;

        Save(data);
        return data;
    }
}
