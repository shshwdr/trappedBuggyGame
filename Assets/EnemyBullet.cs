using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    bool isDead = false;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (isDead)
        {
            return;
        }
        var collision = coll.collider;
        if (collision.tag != "ShootingEnemy" && collision.tag != "EnemyBullet")
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
            GetComponent<Bullet>(). destroy();
        }
        //OnTriggerEnter2D(collision.collider);
    }
}
