using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab;

    private void Start()
    {
        int hasItem = PlayerPrefs.GetInt(itemPrefab.tag, 0);

        if (hasItem == 0)
        {
            Instantiate(itemPrefab, transform.position, transform.rotation);
        }
    }
}
