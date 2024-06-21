using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform personajePrincipal; // Referencia al objeto del personaje principal
    public Transform personajeLobo; // Referencia al objeto del personaje del lobo
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el movimiento de la c�mara
    public Vector3 offset; // Offset de posici�n entre la c�mara y el objetivo

    void LateUpdate()
    {
        Transform target = personajePrincipal; // Establecer el objetivo predeterminado como el personaje principal

        // Verificar si el personaje principal est� activo
        if (personajePrincipal.gameObject.activeSelf)
        {
            target = personajePrincipal; // Si est� activo, establecerlo como el objetivo
        }
        else if (personajeLobo.gameObject.activeSelf)
        {
            target = personajeLobo; // Si el personaje principal no est� activo pero el lobo s�, establecer el lobo como objetivo
        }

        // Calcular la posici�n deseada de la c�mara
        Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z) + offset;

        // Interpolaci�n suave entre la posici�n actual y la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizar la posici�n de la c�mara
        transform.position = smoothedPosition;
    }

}