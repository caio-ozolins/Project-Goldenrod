using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject ironOre;
    private GameObject diamondOre;
    private GameObject placaFerrar;
    private GameObject placaDima;

    private void Start()
    {
        ironOre = GameObject.FindGameObjectWithTag("IronOre");
        placaFerrar = GameObject.FindGameObjectWithTag("PlacaFerrar");

        if (PlayerPrefs.GetInt("IronOre") == 1)
        {
            ironOre.SetActive(false);
            placaFerrar.SetActive(false);
        }

        if (PlayerPrefs.GetInt("DiamondOre") == 1)
        {
            ironOre.SetActive(false);
            placaFerrar.SetActive(false);
        }
        
    }
    
    
}
