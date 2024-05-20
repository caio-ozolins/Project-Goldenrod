using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject ironOre;
    private GameObject placaFerrar;

    private void Start()
    {
        ironOre = GameObject.FindGameObjectWithTag("IronOre");
        placaFerrar = GameObject.FindGameObjectWithTag("PlacaFerrar");

        if (PlayerPrefs.GetInt("IronOre") == 1)
        {
            ironOre.SetActive(false);
            placaFerrar.SetActive(false);
        }
    }
    
    
}
