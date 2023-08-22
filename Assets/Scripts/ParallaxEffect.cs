using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float ParallaxMultiplier;

    private Transform CameraTransform;
    private Vector3 previousCameraPosition;

    private float spriteWidth, spriteHeight, startPositionX, startPositionY;

    void Start()
    {
        CameraTransform = Camera.main.transform;
        previousCameraPosition = CameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
    }

    void LateUpdate()
    {

        float deltaX = (CameraTransform.position.x - previousCameraPosition.x) * ParallaxMultiplier;
        float moveAmountX = CameraTransform.position.x * (1 - ParallaxMultiplier);

        float deltaY = (CameraTransform.position.y - previousCameraPosition.y) * ParallaxMultiplier;
        float moveAmountY = CameraTransform.position.y * (1 - ParallaxMultiplier);

        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = CameraTransform.position;

        transform.Translate(new Vector3(0, deltaY, 0));
        previousCameraPosition = CameraTransform.position;

        if (moveAmountX > startPositionX + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPositionX += spriteWidth;
        }
        else if (moveAmountX < startPositionX - spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPositionX -= spriteWidth;
        }

        if (moveAmountY > startPositionY + spriteHeight)
        {
            transform.Translate(new Vector3(0, spriteHeight, 0));
            startPositionY += spriteHeight;
        }
        else if (moveAmountY < startPositionY - spriteHeight)
        {
            transform.Translate(new Vector3(0, -spriteHeight, 0));
            startPositionY -= spriteHeight;
        }

    }

}
