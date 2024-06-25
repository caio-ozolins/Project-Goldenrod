using System.Collections;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject[] waterPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    void Start()
    {
        StartCoroutine(WaterSpawn());
    }
        
        
    IEnumerator WaterSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            // ReSharper disable once LocalVariableHidesMember
            var position = new Vector3(wanted, transform.position.y); GameObject gameObject = Instantiate(waterPrefab[Random.Range(0, waterPrefab.Length)], position, Quaternion.identity);

            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
        // ReSharper disable once IteratorNeverReturns
    }
    


    }
