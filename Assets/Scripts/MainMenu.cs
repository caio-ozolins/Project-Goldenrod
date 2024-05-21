using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level 00");
        PlayerPrefs.SetInt("picaReta", 0);
        PlayerPrefs.SetInt("Balde", 0);
        PlayerPrefs.SetInt("IronOre", 0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
