using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver = false;

    public static GameManager Instance;

    public SaveData saveData;

    [Header("Win Settings")]
    public int dronesToWin = 100;
    int dronesKilled = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        saveData = SaveSystem.Load();
        UIManager.Instance.UpdateMoneyText(saveData.money);
        UIManager.Instance.UpdateKillText(dronesKilled, dronesToWin);
    }

    public void AddKill()
    {
        dronesKilled++;

        saveData.money += 10;
        SaveSystem.Save(saveData);
        UIManager.Instance.UpdateMoneyText(saveData.money);
        UIManager.Instance.UpdateKillText(dronesKilled, dronesToWin);

        if(dronesKilled >= dronesToWin)
        {
            WinUI.Instance.Show();
        }
    }
}
