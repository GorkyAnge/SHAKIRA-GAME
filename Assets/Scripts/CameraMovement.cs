using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform personajePrincipal; // Referencia al objeto del personaje principal
    public Transform personajeLobo; // Referencia al objeto del personaje del lobo
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el movimiento de la cámara
    public Vector3 offset; // Offset de posición entre la cámara y el objetivo

    void LateUpdate()
    {
        Transform target = personajePrincipal; // Establecer el objetivo predeterminado como el personaje principal

        // Verificar si el personaje principal está activo
        if (personajePrincipal.gameObject.activeSelf)
        {
            target = personajePrincipal; // Si está activo, establecerlo como el objetivo
        }
        else if (personajeLobo.gameObject.activeSelf)
        {
            target = personajeLobo; // Si el personaje principal no está activo pero el lobo sí, establecer el lobo como objetivo
        }

        // Calcular la posición deseada de la cámara
        Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z) + offset;

        // Interpolación suave entre la posición actual y la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizar la posición de la cámara
        transform.position = smoothedPosition;
    }

}