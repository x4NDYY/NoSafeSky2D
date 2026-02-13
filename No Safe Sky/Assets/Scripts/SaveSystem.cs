using UnityEngine;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/save.txt";

    public static void SaveMoney(int money)
    {
        File.WriteAllText (path, money.ToString());
    }

    public static int LoadMoney()
    {
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            return int.Parse(data);
        }

        return 0;
    }
}
