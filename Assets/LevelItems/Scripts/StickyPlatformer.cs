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
        //if (collision.tag == "Player" && collision.transform.parent != transform.parent && collision.transform.parent.parent != transform.parent)
        //{
        //    collision.transform.parent.parent = transform.parent;
        //    //collision.transform.parent.GetComponent<Rigidbody2D>().simulated = false;
        //    collision.transform.parent.GetComponent<Character>().isOnStickPlatform++;
        //    if (!collision.transform.parent.GetComponent<Character>().enabled)
        //    {

        //        Destroy( collision.transform.parent.GetComponent<Rigidbody2D>());
        //    }
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.tag == "Player" && collision.transform.parent!=null && collision.transform.parent.parent == transform.parent)
        //{
        //    collision.transform.parent.parent = transform.parent.parent;
        //    collision.transform.parent.GetComponent<Character>().isOnStickPlatform--;
        //}
    }
}
