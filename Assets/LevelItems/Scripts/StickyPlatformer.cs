using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatformer : MonoBehaviour
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
        if (collision.tag == "GroundCheck" || collision.tag == "Cube")
          // if (collision.tag == "GroundCheck" && collision.transform.parent != transform.parent && (collision.transform.parent == null || collision.transform.parent.parent != transform.parent))
        {
            collision.transform.parent.parent = transform.parent;
            //collision.transform.parent.GetComponent<Rigidbody2D>().simulated = false;
            //collision.transform.parent.GetComponent<Character>().isOnStickPlatform++;
            //if (!collision.transform.parent.GetComponent<Character>().enabled)
            //{

            //    Destroy(collision.transform.parent.GetComponent<Rigidbody2D>());
            //}
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Cube")
    //    // if (collision.tag == "GroundCheck" && collision.transform.parent != transform.parent && (collision.transform.parent == null || collision.transform.parent.parent != transform.parent))
    //    {
    //        collision.collider.transform.parent.parent = transform.parent;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Cube")
    //    // if (collision.tag == "GroundCheck" && collision.transform.parent != transform.parent && (collision.transform.parent == null || collision.transform.parent.parent != transform.parent))
    //    {
    //        collision.collider.transform.parent.parent = transform.parent.parent;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision &&( collision.tag == "GroundCheck" || collision.tag == "Cube"))
        {
            collision.transform.parent.parent = null;
            //collision.transform.parent.GetComponent<Character>().isOnStickPlatform--;
        }
    }
}
