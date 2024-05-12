using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float backgroundSpeed = 0;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += Vector2.right * backgroundSpeed * Time.deltaTime;

    }
}
