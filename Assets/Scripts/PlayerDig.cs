using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDig : MonoBehaviour
{
    private GameObject ironOre;
    private GameObject diamondOre;
    private GameObject coalOre;

    private GameObject placaFerrar;
    private GameObject placaDima;
    private GameObject placaCoal;

    private Sign signIron;
    private Sign signDima;
    private Sign signCoal;

    public GameObject blackScreen;
    public GameObject avisoFerro;
    public GameObject avisoDima;
    public GameObject avisoCoal;

    public Audiomanager audioManager;
    private PlayerMovement player;
    private String tagPlaca;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();

        ironOre = GameObject.FindGameObjectWithTag("IronOre");
        diamondOre = GameObject.FindGameObjectWithTag("DiamondOre");
        coalOre = GameObject.FindGameObjectWithTag("CoalOre");

        placaFerrar = GameObject.FindGameObjectWithTag("PlacaFerrar");
        placaDima = GameObject.FindGameObjectWithTag("PlacaDima");
        placaCoal = GameObject.FindGameObjectWithTag("PlacaCoal");

        signIron = GameObject.FindGameObjectWithTag("PlacaFerrar").GetComponent<Sign>();
        signDima = GameObject.FindGameObjectWithTag("PlacaDima").GetComponent<Sign>();
        signCoal = GameObject.FindGameObjectWithTag("PlacaCoal").GetComponent<Sign>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public void Dig(InputAction.CallbackContext context)
    {
        Debug.Log("Fora");
        if (signIron.nearSign || signDima.nearSign || signCoal.nearSign && context.performed)
        {
            Debug.Log("Dinicio");
            Time.timeScale = 0;
            blackScreen.SetActive(true);

            audioManager.PlaySFX(audioManager.dig);

            if (tagPlaca == "PlacaFerrar")
            {
                Destroy(ironOre);
                Destroy(placaFerrar);
                PlayerPrefs.SetInt("IronOre", 1);
                StartCoroutine(WaitDig());
                avisoFerro.SetActive(true);
            }
            else if (tagPlaca == "PlacaDima")
            {
                Destroy(diamondOre);
                Destroy(placaDima);
                PlayerPrefs.SetInt("DiamondOre", 1);
                StartCoroutine(WaitDig());
                avisoDima.SetActive(true);
            }
            else if (tagPlaca == "PlacaCoal")
            {
                Debug.Log("carvao");
                Destroy(coalOre);
                Destroy(placaCoal);
                PlayerPrefs.SetInt("CoalOre", 1);
                StartCoroutine(WaitDig());
                avisoCoal.SetActive(true);
            }
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
        avisoDima.SetActive(false);
        avisoCoal.SetActive(false);
        blackScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
