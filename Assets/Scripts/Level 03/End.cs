using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject acabou;
    public bool finished;

    private void Awake()
    {
        finished = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Drill"))
        {
            finished=true;
            Time.timeScale = 0;
            blackScreen.SetActive(true);
            acabou.SetActive(true);
        }
    }
}
