using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SignNextLevel : MonoBehaviour
{
    private Sign sign;
    public Audiomanager audioManager;
    public GameObject blackScreen;

    private void Start()
    {
        sign = GameObject.FindGameObjectWithTag("PlacaInicio").GetComponent<Sign>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }

    public void NextLevel(InputAction.CallbackContext context)
    {
        int hasPick = PlayerPrefs.GetInt("picaReta");
        
        if (sign.nearSign && context.performed && hasPick == 1)
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
