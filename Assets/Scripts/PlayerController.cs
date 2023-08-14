using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public PlayerShot playerShot;

    public Camera camera;

    public Rigidbody2D rb;
    public Rigidbody2D shot;
    public Transform positionShot;
    public Vector2 input, inputRotacion;
    float shipAngle;
    
    public Joystick joystickDerecho, joystickIzquierdo;
    public float speed;
    public float rotationInterpolation = 0.4f;
    public bool isMovingController, isMovingShot;

    public bool activarDisparo = true;

    public float coolDownPeriodInSeconds;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = this.transform.position;

        input.x = joystickDerecho.Horizontal;
        input.y = joystickDerecho.Vertical;

        inputRotacion.x = joystickIzquierdo.Horizontal;
        inputRotacion.y = joystickIzquierdo.Vertical;

        if (input.x != 0 || input.y != 0)
        {
            isMovingController = true;
        }
        else
        {
            isMovingController = false;
            rb.velocity = new Vector2(0, 0);
            //rb.velocity = Mathf.Lerp(speed, 0, 1);
        }

        if (inputRotacion.x != 0 || inputRotacion.y != 0)
        {
            isMovingShot = true;
        }
        else
        {
            isMovingShot = false;
        }

        if (isMovingController && isMovingShot)
        {
            //sin rotacion

        }else if (isMovingController)
        {
            Rotation();
        }
    }


    private void FixedUpdate()
    {
        float timeStamp = Time.time + coolDownPeriodInSeconds;

        if (isMovingController)
        {
            rb.velocity = input * speed * Time.fixedDeltaTime;
        }

        AloneRotation();

        if (isMovingShot)
        {
            if (timeStamp <= Time.time)
            {
                Instantiate(shot, positionShot.position, this.transform.rotation);
            }
        }

        /*if(joystickDerecho.DeadZone < joystickDerecho.HandleRange)
        {

        }*/
        
        
    }

    void Rotation()
    {
        Vector2 lookDir = new Vector2(input.y, input.x);

        if (isMovingController)
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

    void AloneRotation()
    {
        Vector2 lookDirRotacion = new Vector2(inputRotacion.y, inputRotacion.x);

        if (isMovingShot)
        {
            shipAngle = Mathf.Atan2(lookDirRotacion.x, lookDirRotacion.y) * Mathf.Rad2Deg;
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

    IEnumerator Shot()
    {
        activarDisparo = false;
        yield return new WaitForSeconds(1.0f);
        Instantiate(shot, positionShot.position, this.transform.rotation);
        activarDisparo = true;
    }
}
