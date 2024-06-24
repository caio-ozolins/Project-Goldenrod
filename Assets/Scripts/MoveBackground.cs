using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float backgroundSpeed;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += Vector2.right * (backgroundSpeed * Time.deltaTime);

    }
}
