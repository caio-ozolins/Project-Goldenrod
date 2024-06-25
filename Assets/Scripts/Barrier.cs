using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject warningUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (PlayerPrefs.GetInt("FixedDrill") == 0 || PlayerPrefs.GetInt("CoalOre") == 0))
        {
            warningUI.SetActive(true);
        }
        else if (collision.CompareTag("Player") && PlayerPrefs.GetInt("Water") == 0)
        {
            warningUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            warningUI.SetActive(false);
        }
    }
}
