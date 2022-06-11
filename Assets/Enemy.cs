using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    HPObject hpObject;
    bool isActive = true;
    PlayerMovement[] players;
    Transform target;
    Rigidbody2D rb;
    public float speed = 5;
    public float attackRange = 2;
    public LayerMask collideLayer;
    // Start is called before the first frame update
    void Start()
    {
        hpObject = GetComponent<HPObject>();
        players = GameObject.FindObjectsOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpObject.isAlive)
        {
            int index = Utils.findClosestIndex(transform, players.ToList());
            target = players[index].transform;

            var distance = (target.transform.position - transform.position).magnitude;
            if (distance < attackRange)
            {
                target.GetComponent<HPObject>().beAttacked(1);

                //rb.velocity = ;
            }
            else
            {
                var dir = (target.transform.position - transform.position).normalized;
                //RaycastHit2D hit = Physics2D.Raycast(transform.position, dir,1, collideLayer);
                //if (!hit)
                //{
                //    rb.MovePosition(transform.position + dir * speed * Time.deltaTime);

                //}
                rb.velocity = dir * speed;
                //rb.AddForce(dir * Time.deltaTime * speed,ForceMode2D.Impulse);
            }

        }
    }
}
