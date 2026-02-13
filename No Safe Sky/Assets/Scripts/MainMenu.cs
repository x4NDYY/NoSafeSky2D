using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
