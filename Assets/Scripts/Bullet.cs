using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody2D rigidbody;

    public float speedBullet, tiempoDestruirBala;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody.AddForce(new Vector2(playerController.inputRotacion.x * speedBullet * Time.deltaTime, playerController.inputRotacion.y * speedBullet * Time.deltaTime));
        rigidbody.velocity = (new Vector2(playerController.inputRotacion.x * speedBullet * Time.deltaTime, playerController.inputRotacion.y * speedBullet * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyBullet", tiempoDestruirBala);
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
