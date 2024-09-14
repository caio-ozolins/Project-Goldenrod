using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject background;
    public GameObject pauseMenu;
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    public GameObject resolutionPanel;
    public GameObject audioPanel;
    public bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("p"))
        {
            if (isPaused == false)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public void Pause()
    {
        pauseMenu.SetActive(true);
        background.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        background.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        resolutionPanel.SetActive(false);
        audioPanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}