using TMPro;
using UnityEngine;

public class TemperatureIncrease : MonoBehaviour
{
    public TextMeshProUGUI temperatureText; // Referência ao componente TextMeshPro
    private float currentTemperature = 40f; // Inicia em 40º
    private float increaseRate = 3f; // Taxa de aumento em º por segundo

    void Update()
    {
        // Aumenta a temperatura por segundo
        currentTemperature += increaseRate * Time.deltaTime;

        // Atualiza o texto para refletir o novo valor de temperatura
        temperatureText.text = currentTemperature.ToString("F0") + "º";
    }
}
