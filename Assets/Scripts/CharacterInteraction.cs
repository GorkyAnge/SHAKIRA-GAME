using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public int requiredMoney = 7000; // Dinero requerido para ganar
    public GameObject winPanel; // Panel que se muestra cuando se gana
    public GameObject losePanel; // Panel que se muestra cuando se pierde
    public float interactionDistance = 2.0f; // Distancia para interactuar

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Asegúrate de que los paneles están desactivados al inicio
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    private void Update()
    {
        // Comprueba la distancia entre el jugador y el personaje
        if (Vector3.Distance(playerTransform.position, transform.position) <= interactionDistance)
        {
            CheckMoney();
        }
    }

    private void CheckMoney()
    {
        if (MoneyCounter.Instance.GetMoneyAmount() >= requiredMoney)
        {
            // Activa el panel de ganar
            winPanel.SetActive(true);
        }
        else
        {
            // Activa el panel de perder
            losePanel.SetActive(true);
        }
    }
}
