using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform rigidbody;

    public float speedBullet;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.Translate(Vector3.forward * Time.deltaTime);

        Invoke("DestroyBullet", 1);
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
