using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public static WinUI Instance;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void MainMenu()
    {
        GameManager.IsGameOver = false;
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
