using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float ParallaxMultiplier;

    private Transform CameraTransform;
    private Vector3 previousCameraPosition;

    private float spriteWidth, startPosition;

    void Start()
    {
        CameraTransform = Camera.main.transform;
        previousCameraPosition = CameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }

    void LateUpdate()
    {

        float deltaX = (CameraTransform.position.x - previousCameraPosition.x) * ParallaxMultiplier;
        float moveAmount = CameraTransform.position.x * (1 - ParallaxMultiplier);
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = CameraTransform.position;

        if (moveAmount > startPosition + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPosition += spriteWidth;
        }
        else if (moveAmount < startPosition - spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;
        }



    }
}
