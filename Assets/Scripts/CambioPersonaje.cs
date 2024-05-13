using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPersonaje : MonoBehaviour
{
    public GameObject shakira;
    public GameObject shakiraLoba;
    private bool isTransforming = false;
    private float transformationDuration = 30f; // Duración de la transformación en segundos
    private float transformationTimer = 0f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = shakira.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isTransforming)
        {
            StartCoroutine(TransformShakiraLoba());
        }

        if (isTransforming)
        {
            transformationTimer += Time.deltaTime;
            if (transformationTimer >= transformationDuration)
            {
                transformationTimer = 0f;
                isTransforming = false;
                shakira.SetActive(true);
                shakiraLoba.SetActive(false);
            }
        }
    }

    IEnumerator TransformShakiraLoba()
    {
        isTransforming = true;
        shakira.SetActive(false);
        shakiraLoba.SetActive(true);
        shakiraLoba.transform.position = shakira.transform.position; // Posicionar en la posición de Shakira
        yield return new WaitForSeconds(transformationDuration);
    }
}
