using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver = false;

    public static GameManager Instance;

    public int money = 0;
    public int rewardPerDrone = 10;

    [Header("Win Settings")]
    public int dronesToWin = 100;
    int dronesKilled = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        money = SaveSystem.LoadMoney();
        UIManager.Instance.UpdateMoneyText(money);
        UIManager.Instance.UpdateKillText(dronesKilled, dronesToWin);
    }

    public void AddKill()
    {
        dronesKilled++;

        money += rewardPerDrone;
        SaveSystem.SaveMoney(money);

        UIManager.Instance.UpdateKillText(dronesKilled, dronesToWin);
        UIManager.Instance.UpdateMoneyText(money);

        if(dronesKilled >= dronesToWin)
        {
            WinUI.Instance.Show();
        }
    }
}
