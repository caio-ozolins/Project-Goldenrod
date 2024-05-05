using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level 00");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
