using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public Audiomanager audioManager;
    private PauseMenu pauseMenu;

    int count = 0;

    private void Awake()
    {
        audioManager.PlaySFX(audioManager.drillOn);
    }

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    private void Update()
    {
        if (pauseMenu.isPaused)
        {
            count = 1;
            audioManager.PauseSFX(audioManager.drillOn);
        }
        else if (!pauseMenu.isPaused && count == 1) 
        {
            count = 0;
            audioManager.PlaySFX(audioManager.drillOn);
        }
    }
}
