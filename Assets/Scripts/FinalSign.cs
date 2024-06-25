using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FinalSign : MonoBehaviour
{
    public GameObject signWater;
    public bool nearSign;
    public GameObject blackScreen;
    public Audiomanager audioManager;
    public GameObject avisoBroca02;
    public GameObject avisoFinal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nearSign = true;
            signWater.SetActive(true);
        }
    }

    public void End(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 0;

            //Parar Fumaça
            PlayerPrefs.SetInt("DrillReady", 1);
            StartCoroutine(WaitDig());
            //avisoBroca02.SetActive(true);
            audioManager.PlaySFX(audioManager.drillOn);

            StartCoroutine(WaitEnd());
            blackScreen.SetActive(true);
            avisoFinal.SetActive(true);
        }
    }

    private IEnumerator WaitDig()
    {
        yield return new WaitForSecondsRealtime(2);
        blackScreen.SetActive(false);
    }
    private IEnumerator WaitEnd()
    {
        yield return new WaitForSecondsRealtime(5);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nearSign = false;
            signWater.SetActive(false);
        }
    }
}
