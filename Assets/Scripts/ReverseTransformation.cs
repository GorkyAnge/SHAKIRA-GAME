using UnityEngine;
using System.Collections;

public class ReverseTransformation : MonoBehaviour
{
    public GameObject shakira;
    public GameObject shakiraLoba;

    [SerializeField] private float transformationDuration; // Duraci�n de la transformaci�n en segundos

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
            shakira.transform.position = shakiraLoba.transform.position; // Mueve la posici�n de Shakira a la posici�n de Shakira Loba
        }
    }
}
