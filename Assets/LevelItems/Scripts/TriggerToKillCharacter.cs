using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToKillCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponentInParent<HPObject>().beAttacked();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            var hpObject = collision.collider.GetComponentInParent<HPObject>();
            if(hpObject== null)
            {
                collision.collider.GetComponent<HPObject>();
            }
            if (hpObject != null)
            {

                hpObject.beAttacked();
            }

        }
    }
}
