using UnityEngine;

public class MoneyCollectible : MonoBehaviour
{
    public int value = 1; // Valor del dinero recogido

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // Accedemos al script del contador de dinero y le sumamos el valor de este objeto
            MoneyCounter.Instance.AddMoney(value);
            // Destruye el objeto de dinero después de ser recogido
            Destroy(gameObject);
        }
    }
}
