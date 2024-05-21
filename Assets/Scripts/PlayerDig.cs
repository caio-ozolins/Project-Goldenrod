using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDig : MonoBehaviour
{
    private GameObject ironOre;
    private GameObject diamondOre;
    private GameObject coalOre;
    private GameObject waterBefore;

    private GameObject atrocidade;
    private GameObject atrocidadeJr;

    private GameObject placaFerrar;
    private GameObject placaDima;
    private GameObject placaCoal;
    private GameObject placaWater;

    private Sign signIron;
    private Sign signDima;
    private Sign signCoal;
    private Sign signWater;

    public GameObject blackScreen;
    public GameObject avisoFerro;
    public GameObject avisoDima;
    public GameObject avisoCoal;
    public GameObject avisoWater;

    public Audiomanager audioManager;
    private PlayerMovement player;
    private String tagPlaca;
    private GameObject waterSpawner;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
        waterSpawner = GameObject.FindGameObjectWithTag("WaterSpawner");

        atrocidade = GameObject.FindGameObjectWithTag("Atrocidade");
        atrocidadeJr = GameObject.FindGameObjectWithTag("AtrocidadeJr");

        ironOre = GameObject.FindGameObjectWithTag("IronOre");
        diamondOre = GameObject.FindGameObjectWithTag("DiamondOre");
        coalOre = GameObject.FindGameObjectWithTag("CoalOre");
        waterBefore = GameObject.FindGameObjectWithTag("WaterBefore");

        placaFerrar = GameObject.FindGameObjectWithTag("PlacaFerrar");
        placaDima = GameObject.FindGameObjectWithTag("PlacaDima");
        placaCoal = GameObject.FindGameObjectWithTag("PlacaCoal");
        placaWater = GameObject.FindGameObjectWithTag("PlacaWater");

        signIron = GameObject.FindGameObjectWithTag("PlacaFerrar").GetComponent<Sign>();
        signDima = GameObject.FindGameObjectWithTag("PlacaDima").GetComponent<Sign>();
        signCoal = GameObject.FindGameObjectWithTag("PlacaCoal").GetComponent<Sign>();
        signWater = GameObject.FindGameObjectWithTag("PlacaWater").GetComponent<Sign>();

        player = FindObjectOfType<PlayerMovement>();
    }

    public void Dig(InputAction.CallbackContext context)
    {
        if (signIron.nearSign || signDima.nearSign || signCoal.nearSign || signWater.nearSign && context.performed)
        {
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
                Destroy(coalOre);
                Destroy(placaCoal);
                PlayerPrefs.SetInt("CoalOre", 1);
                StartCoroutine(WaitDig());
                avisoCoal.SetActive(true);
            }else if (tagPlaca == "PlacaWater")
            {
                Destroy(waterBefore);
                Destroy(placaWater);
                Destroy(waterSpawner);
                Destroy(atrocidade);
                Destroy(atrocidadeJr);
                PlayerPrefs.SetInt("Water", 1);
                StartCoroutine(WaitDig());
                avisoWater.SetActive(true);
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
        avisoWater.SetActive(false);
        blackScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
