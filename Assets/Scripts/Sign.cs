using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject signUI;
    public bool nearSign = false;
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PlacaInicio"))
        {
            if (collision.CompareTag("Player") && player.hasItem)
            {
                nearSign = true;
                signUI.SetActive(true);
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
        }
    }

}
