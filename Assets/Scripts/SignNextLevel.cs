using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SignNextLevel : MonoBehaviour
{
    private Sign sign;
    private PlayerMovement player;
    public Audiomanager audioManager;
    public GameObject blackScreen;

    private void Start()
    {
        sign = GameObject.FindGameObjectWithTag("PlacaInicio").GetComponent<Sign>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public void NextLevel(InputAction.CallbackContext context)
    {
        if (sign.nearSign && context.performed && player.hasItem)
        {
            blackScreen.SetActive(true);

            audioManager.PlaySFX(audioManager.dig);

            StartCoroutine(WaitDelay());
        }
    }
    private IEnumerator WaitDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("Level 01");
    }
}
