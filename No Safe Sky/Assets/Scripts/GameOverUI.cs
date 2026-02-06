using UnityEngine;
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

        Cursor.visible = true;

        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Restart()
    {
        GameManager.IsGameOver = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
