using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Velocidade de movimento do Tilemap

    void Update()
    {
        // Move o Tilemap para cima
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
