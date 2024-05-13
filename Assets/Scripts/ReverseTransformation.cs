using UnityEngine;
using System.Collections;

public class ReverseTransformation : MonoBehaviour
{
    public GameObject shakira;
    public GameObject shakiraLoba;

    [SerializeField] private float transformationDuration; // Duración de la transformación en segundos

    private float transformationTimer = 0f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = shakira.transform.position;
    }

    void Update()
    {
        transformationTimer += Time.deltaTime;
        if (transformationTimer >= transformationDuration)
        {
            transformationTimer = 0f;
            shakira.SetActive(true);
            shakiraLoba.SetActive(false);
            shakira.transform.position = shakiraLoba.transform.position; // Mueve la posición de Shakira a la posición de Shakira Loba
        }
    }
}
