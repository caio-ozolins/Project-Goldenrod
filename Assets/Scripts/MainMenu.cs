using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level 00");
        PlayerPrefs.SetInt("picaReta", 0);
        PlayerPrefs.SetInt("IronOre", 0);
        PlayerPrefs.SetInt("DiamondOre", 0);
        PlayerPrefs.SetInt("CoalOre", 0);
        PlayerPrefs.SetInt("Water", 0);
        PlayerPrefs.SetInt("CanFixDrill", 0);
        PlayerPrefs.SetInt("FixedDrill", 0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
