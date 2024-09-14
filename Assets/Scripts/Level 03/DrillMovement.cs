using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do objeto

    private void Awake()
    {
        float agoraVai = 1;
    }

    void Update()
    {
        // Captura a entrada do usuário
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move o objeto para a direita/esquerda
        Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);
    }
}
