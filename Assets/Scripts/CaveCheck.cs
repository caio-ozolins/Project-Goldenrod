using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCheck : MonoBehaviour
{
    private Collider2D caveCheck;

    Audiomanager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<Audiomanager>();
        caveCheck = GameObject.FindGameObjectWithTag("Check").GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        audioManager.PlaySFX(audioManager.cave);
    }
}
