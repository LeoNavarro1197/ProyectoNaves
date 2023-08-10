using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public PlayerController playerController;

    public Rigidbody2D rb;
    Vector2 input;
    float shipAngle;

    public Joystick joystick;
    public float rotationInterpolation = 0.4f;
    public bool isMovingShot;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = joystick.Horizontal;
        input.y = joystick.Vertical;

        if (input.x != 0 || input.y != 0)
        {
            isMovingShot = true;
        }
        else
        {
            isMovingShot = false;
        }
    }


    private void FixedUpdate()
    {
        GetRotation();
    }

    void GetRotation()
    {
        
        if (!playerController.isMovingController)
        {
            Vector2 lookDir = new Vector2(input.y, input.x);

            if (isMovingShot)
            {
                shipAngle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;
            }

            if (rb.rotation <= -90 && shipAngle >= 90)
            {
                rb.rotation += 360;
                rb.rotation = Mathf.Lerp(rb.rotation, shipAngle, rotationInterpolation);
            }
            else if (rb.rotation >= 90 && shipAngle <= -90)
            {
                rb.rotation -= 360;
                rb.rotation = Mathf.Lerp(rb.rotation, shipAngle, rotationInterpolation);
            }
            else
            {
                rb.rotation = Mathf.Lerp(rb.rotation, shipAngle, rotationInterpolation);
            }
        }
    }
}
