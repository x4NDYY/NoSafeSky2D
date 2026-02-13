using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI killText;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        Instance = this;
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
