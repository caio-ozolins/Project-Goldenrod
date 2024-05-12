using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float minX, maxX, minY, maxY;
    
    private void FixedUpdate()
    {
        transform.position = Player.position + new Vector3 (0,0,-10);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}
