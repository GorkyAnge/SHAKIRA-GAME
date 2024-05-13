using UnityEngine;
using System.Collections;

public class TransformacionShakira : MonoBehaviour
{
    public GameObject shakira;
    public GameObject shakiraLoba;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = shakira.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            shakira.SetActive(false);
            shakiraLoba.SetActive(true);
            shakiraLoba.transform.position = shakira.transform.position; // Posicionar en la posición de Shakira
        }

    }

}
