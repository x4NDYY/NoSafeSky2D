using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        GameManager.IsGameOver = true;
        AudioListener.volume = 0f;

        Cursor.visible = true;

        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Restart()
    {
        GameManager.IsGameOver = false;
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        GameManager.IsGameOver = false;
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        SceneManager.LoadScene("MenuScene");
        Cursor.visible = true;
    }

}
