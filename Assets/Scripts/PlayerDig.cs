using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDig : MonoBehaviour
{
    private GameObject ironOre;
    private GameObject diamondOre;
    private GameObject placaFerrar;
    private GameObject placaDima;
    private Sign signIron;
    private Sign signDima;
    private PlayerMovement player;
    public GameObject blackScreen;
    public GameObject avisoFerro;
    public Audiomanager audioManager;
    private String tagPlaca;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
        ironOre = GameObject.FindGameObjectWithTag("IronOre");
        diamondOre = GameObject.FindGameObjectWithTag("DiamondOre");
        placaFerrar = GameObject.FindGameObjectWithTag("PlacaFerrar");
        placaDima = GameObject.FindGameObjectWithTag("PlacaDima");
        signIron = GameObject.FindGameObjectWithTag("PlacaFerrar").GetComponent<Sign>();
        signDima = GameObject.FindGameObjectWithTag("PlacaDima").GetComponent<Sign>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public void Dig(InputAction.CallbackContext context)
    {
        if (signIron.nearSign || signDima.nearSign && context.performed)
        {
            Time.timeScale = 0;
            blackScreen.SetActive(true);

            audioManager.PlaySFX(audioManager.dig);

            if (tagPlaca == "PlacaFerrar")
            {
                Destroy(ironOre);
                Destroy(placaFerrar);
                PlayerPrefs.SetInt("IronOre", 1);
            } else if (tagPlaca == "PlacaDima")
            {
                Destroy(diamondOre);
                Destroy(placaDima);
                PlayerPrefs.SetInt("DiamondOre", 1);
            }
            
            StartCoroutine(WaitDig());

            avisoFerro.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        tagPlaca = other.tag;
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
