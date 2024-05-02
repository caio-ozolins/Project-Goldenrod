using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvaMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject background;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void Vanish()
    {
        this.background.SetActive(false);
    }

    public void StartGame()
    {
        Vanish();
        Time.timeScale = 1;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
