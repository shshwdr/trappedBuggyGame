using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float force = 10f;
    bool isDead = false;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (isDead)
        {
            return;
        }
        var collision = coll.collider;
        if (collision.tag != "Player" && collision.tag != "Platform" && collision.tag != "Bullet")
        {
            if (collision.GetComponent<HPObject>())
            {
                collision.GetComponent<HPObject>().beAttacked();
            }
            if (collision.GetComponentInParent<HPObject>())
            {
                collision.GetComponentInParent<HPObject>().beAttacked();
            }
            if (collision.GetComponent<Bullet>())
            {
                collision.GetComponent<Bullet>().destroy();
            }

            if (collision.GetComponent<Rigidbody2D>())
            {
                collision.GetComponent<Rigidbody2D>().AddForce(GetComponent<Bullet>().dir * force);

            }
            GetComponentInChildren<SpriteRenderer>().color = Color.gray;
            isDead = true;
            //GetComponent<Collider2D>().isTrigger = true;
            //rb.velocity = Vector3.zero;
            GetComponent<Bullet>().destroy();
        }
        else if (collision.tag == "Player")
        {
            var player = GetComponent<PlayerMovement>();
            if (player == null)
            {
                player = GetComponentInParent<PlayerMovement>();
            }
            if (player != null)
            {

                //if (!player.ability.GetComponent<Shoot>())
                {
                    if (player.GetComponent<Rigidbody2D>())
                    {
                        player.GetComponent<Rigidbody2D>().AddForce(GetComponent<Bullet>().dir * force);

                    }
                }
            }
            GetComponent<Bullet>().destroy();
        }
        //OnTriggerEnter2D(collision.collider);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        var player = GetComponent<PlayerMovement>();
    //        if (player == null)
    //        {
    //            player = GetComponentInParent<PlayerMovement>();
    //        }
    //        //if (!player.ability.GetComponent<Shoot>())
    //        {
    //            player.GetComponent<Rigidbody2D>().AddForce(GetComponent<Bullet>().dir * force);
    //        }
    //        isDead = true;
    //        GetComponent<Bullet>().destroy();
    //    }
    //}
}
