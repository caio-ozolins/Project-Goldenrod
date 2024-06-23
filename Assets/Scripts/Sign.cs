using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject signUI;
    public GameObject signZero;
    public GameObject signHalf01;
    public GameObject signHalf02;
    public GameObject signAll;
    public GameObject signHot;
    public GameObject signWater;
    public GameObject signUI2;
    public bool nearSign = false;
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("FixedDrill") == 1 && PlayerPrefs.GetInt("Happened") == 1)
        {
            signAll.SetActive(false);
            signHot.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag == "PlacaInicio")
        {
            if (collision.CompareTag("Player") && PlayerPrefs.GetInt("picaReta") == 1)
            {
                nearSign = true;
                signUI.SetActive(true);
            }
            else if (collision.CompareTag("Player") && PlayerPrefs.GetInt("picaReta") == 0)
            {
                nearSign = true;
                signUI2.SetActive(true);
            }
        }
        else if (this.tag == "PlacaBroca")
        {
            if (collision.CompareTag("Player") && PlayerPrefs.GetInt("IronOre") == 0 && PlayerPrefs.GetInt("DiamondOre") == 0)
            {
                nearSign = true;
                signZero.SetActive(true);
            }
            if (collision.CompareTag("Player") && PlayerPrefs.GetInt("IronOre") == 1 && PlayerPrefs.GetInt("DiamondOre") == 1)
            {
                nearSign = true;
                signAll.SetActive(true);
            }
            if (collision.CompareTag("Player") && PlayerPrefs.GetInt("IronOre") == 1 || PlayerPrefs.GetInt("DiamondOre") == 1)
            {
                if (PlayerPrefs.GetInt("IronOre") == 1 && PlayerPrefs.GetInt("DiamondOre") == 0)
                {
                    nearSign = true;
                    signHalf01.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("IronOre") == 0 && PlayerPrefs.GetInt("DiamondOre") == 1)
                {
                    nearSign = true;
                    signHalf02.SetActive(true);
                }
            }
            if (collision.CompareTag("Player") && PlayerPrefs.GetInt("FixedDrill") == 1 && PlayerPrefs.GetInt("Water") == 0)
            {
                nearSign = true;
                signHot.SetActive(true);
            }
            if (collision.CompareTag("Player") && PlayerPrefs.GetInt("FixedDrill") == 1 && PlayerPrefs.GetInt("Water") == 1)
            {
                nearSign = true;
                signWater.SetActive(true);
            }
        }
        else if (collision.CompareTag("Player"))
        {
            nearSign = true;
            signUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nearSign = false;
            signUI.SetActive(false);
            signUI2.SetActive(false);
            signZero.SetActive(false);
            signHalf01.SetActive(false);
            signHalf02.SetActive(false);
            signAll.SetActive(false);
            signHot.SetActive(false);
        }

        PlayerPrefs.SetInt("Happened", 0);
    }

}
