using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDig : MonoBehaviour
{
    private GameObject ironOre;
    private GameObject placaFerrar;
    private Sign sign;
    private PlayerMovement player;
    public GameObject blackScreen;
    public GameObject avisoFerro;
    public Audiomanager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
        ironOre = GameObject.FindGameObjectWithTag("IronOre");
        placaFerrar = GameObject.FindGameObjectWithTag("PlacaFerrar");
        sign = FindObjectOfType<Sign>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public void Dig(InputAction.CallbackContext context)
    {
        if (sign.nearSign && context.performed)
        {
            Time.timeScale = 0;
            blackScreen.SetActive(true);

            audioManager.PlaySFX(audioManager.dig);
            Destroy(ironOre);
            Destroy(placaFerrar);
            PlayerPrefs.SetInt("IronOre", 1);

            StartCoroutine(WaitDig());

            avisoFerro.SetActive(true);
        }
    }

    private IEnumerator WaitDig()
    {
        yield return new WaitForSecondsRealtime(2);
        blackScreen.SetActive(false);
    }

    public void CloseWarning()
    {
        avisoFerro.SetActive(false);
        Time.timeScale = 1;
    }
}
