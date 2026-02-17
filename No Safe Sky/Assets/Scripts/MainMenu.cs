using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    public SaveData saveData;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject shopPanel;

    public TextMeshProUGUI moneyText;
    public void Start()
    {
        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        Debug.Log(Application.persistentDataPath);
        GameManager.IsGameOver = false;
        Cursor.visible = true;

        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShopMenu()
    {
        saveData = SaveSystem.Load();
        UpdateMoneyText(saveData.money);
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void ExitShopMenu()
    {
        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    public void UpdateMoneyText(int money)
    {
        moneyText.text = "" + money;
    }
}
