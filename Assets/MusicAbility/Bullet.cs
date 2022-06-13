using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 dir;
    public float speed = 2;
    Rigidbody2D rb;
    public LayerMask destroyLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag != "Player" && collision.tag != "Bullet")
        //{
        //    if (collision.GetComponent<HPObject>())
        //    {
        //        collision.GetComponent<HPObject>().beAttacked();
        //    }
        //    Destroy(gameObject);
        //}
    }
    public void init(Vector3 dir)
    {
        this.dir = dir;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir*speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
