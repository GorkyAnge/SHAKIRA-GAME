using UnityEngine;

public class ReverseTransformation : MonoBehaviour
{
    public GameObject shakira;
    public GameObject shakiraLoba;
    public GameObject dustPrefab; // Referencia al prefab Dust

    [SerializeField] private float transformationDuration; // Duraci�n de la transformaci�n en segundos

    private float transformationTimer = 0f;
    public float dustOffsetZ = -2.0f; // Desplazamiento en el eje Z para el prefab Dust

    void Update()
    {
        transformationTimer += Time.deltaTime;
        if (transformationTimer >= transformationDuration)
        {
            // Guardar la posici�n actual de Shakira Loba
            Vector3 transformPosition = shakiraLoba.transform.position;

            transformationTimer = 0f;
            shakira.SetActive(true);
            shakiraLoba.SetActive(false);
            shakira.transform.position = transformPosition; // Mueve la posici�n de Shakira a la posici�n de Shakira Loba

            // Ajustar la posici�n para el prefab Dust por encima de Shakira en el eje Z
            Vector3 dustPosition = transformPosition + new Vector3(0, 0, dustOffsetZ);

            // Instanciar el prefab Dust en la posici�n ajustada
            Instantiate(dustPrefab, dustPosition, Quaternion.identity);
        }
    }
}
