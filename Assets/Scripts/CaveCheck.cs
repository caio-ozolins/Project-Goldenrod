using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCheck : MonoBehaviour
{
    Audiomanager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<Audiomanager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.cave);
        }        
    }
}
