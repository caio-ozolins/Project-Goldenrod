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
    private Sign signBroca;

    public GameObject blackScreen;
    public GameObject avisoFerro;
    public GameObject avisoDima;
    public GameObject avisoCoal;
    public GameObject avisoWater;
    public GameObject avisoBroca01;
    public GameObject avisoBroca02;

    public Audiomanager audioManager;
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
        signBroca = GameObject.FindGameObjectWithTag("PlacaBroca").GetComponent<Sign>();
    }

    public void Dig(InputAction.CallbackContext context)
    {
        if (signIron.nearSign || signDima.nearSign || signCoal.nearSign || signWater.nearSign || signBroca.nearSign && context.performed)
        {
            switch (tagPlaca)
            {
                case "PlacaFerrar":
                    Time.timeScale = 0;
                    blackScreen.SetActive(true);

                    audioManager.PlaySFX(audioManager.dig);

                    Destroy(ironOre);
                    Destroy(placaFerrar);
                    PlayerPrefs.SetInt("IronOre", 1);
                    StartCoroutine(WaitDig());
                    avisoFerro.SetActive(true);
                    break;
                case "PlacaDima":
                    Time.timeScale = 0;
                    blackScreen.SetActive(true);

                    audioManager.PlaySFX(audioManager.dig);

                    Destroy(diamondOre);
                    Destroy(placaDima);
                    PlayerPrefs.SetInt("DiamondOre", 1);
                    StartCoroutine(WaitDig());
                    avisoDima.SetActive(true);
                    break;
                case "PlacaCoal":
                    Time.timeScale = 0;
                    blackScreen.SetActive(true);

                    audioManager.PlaySFX(audioManager.dig);

                    Destroy(coalOre);
                    Destroy(placaCoal);
                    PlayerPrefs.SetInt("CoalOre", 1);
                    StartCoroutine(WaitDig());
                    avisoCoal.SetActive(true);
                    break;
                case "PlacaWater":
                    Time.timeScale = 0;
                    blackScreen.SetActive(true);

                    audioManager.PlaySFX(audioManager.dig);

                    Destroy(waterBefore);
                    Destroy(placaWater);
                    Destroy(waterSpawner);
                    Destroy(atrocidade);
                    Destroy(atrocidadeJr);
                    PlayerPrefs.SetInt("Water", 1);
                    StartCoroutine(WaitDig());
                    avisoWater.SetActive(true);
                    break;
                case "PlacaBroca" when PlayerPrefs.GetInt("IronOre") == 1 && PlayerPrefs.GetInt("DiamondOre") == 1:
                    Time.timeScale = 0;
                    blackScreen.SetActive(true);

                    audioManager.PlaySFX(audioManager.dig);

                    //Ativar sprite broca
                    //Começar fumaça
                    PlayerPrefs.SetInt("FixedDrill", 1);
                    PlayerPrefs.SetInt("Happened", 1);
                    StartCoroutine(WaitDig());
                    avisoBroca01.SetActive(true);
                    break;
                case "PlacaBroca" when PlayerPrefs.GetInt("FixedDrill") == 1 && PlayerPrefs.GetInt("Water") == 1:
                    Time.timeScale = 0;
                    blackScreen.SetActive(true);

                    audioManager.PlaySFX(audioManager.dig);

                    //Parar Fumaça
                    PlayerPrefs.SetInt("DrillReady", 1);
                    StartCoroutine(WaitDig());
                    //Start som broca
                    avisoBroca02.SetActive(true);
                    break;
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
        Time.timeScale = 1;
        avisoFerro.SetActive(false);
        avisoDima.SetActive(false);
        avisoCoal.SetActive(false);
        avisoWater.SetActive(false);
        avisoBroca01.SetActive(false);
        avisoBroca02.SetActive(false);
        blackScreen.SetActive(false);
    }
}