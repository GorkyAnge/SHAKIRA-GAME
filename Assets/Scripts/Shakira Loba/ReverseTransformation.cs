using UnityEngine;

public class ReverseTransformation : MonoBehaviour
{
    public GameObject shakira;
    public GameObject shakiraLoba;
    public GameObject dustPrefab; // Referencia al prefab Dust

    [SerializeField] private float transformationDuration; // Duración de la transformación en segundos

    private float transformationTimer = 0f;
    public float dustOffsetZ = -2.0f; // Desplazamiento en el eje Z para el prefab Dust

    void Update()
    {
        transformationTimer += Time.deltaTime;
        if (transformationTimer >= transformationDuration)
        {
            // Guardar la posición actual de Shakira Loba
            Vector3 transformPosition = shakiraLoba.transform.position;

            transformationTimer = 0f;
            shakira.SetActive(true);
            shakiraLoba.SetActive(false);
            shakira.transform.position = transformPosition; // Mueve la posición de Shakira a la posición de Shakira Loba

            // Ajustar la posición para el prefab Dust por encima de Shakira en el eje Z
            Vector3 dustPosition = transformPosition + new Vector3(0, 0, dustOffsetZ);

            // Instanciar el prefab Dust en la posición ajustada
            Instantiate(dustPrefab, dustPosition, Quaternion.identity);
        }
    }
}
