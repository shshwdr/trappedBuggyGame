using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    bool isDead = false;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (isDead)
        {
            return;
        }
        var collision = coll.collider;
        if (collision.tag != "Player" && collision.tag != "Bullet")
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
            GetComponentInChildren<SpriteRenderer>().color = Color.gray;
            isDead = true;
            //GetComponent<Collider2D>().isTrigger = true;
            //rb.velocity = Vector3.zero;
            Destroy(gameObject, 0.1f);
        }
        //OnTriggerEnter2D(collision.collider);
    }
}
