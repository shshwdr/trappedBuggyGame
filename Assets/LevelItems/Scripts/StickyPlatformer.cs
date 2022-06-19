using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatformer : MonoBehaviour
{
    List<Collider2D> TriggerList = new List<Collider2D>();
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
            if (!TriggerList.Contains(collision))
            {
                TriggerList.Add(collision);
                collision.transform.parent.parent = transform.parent;
            }
            //collision.transform.parent.GetComponent<Rigidbody2D>().simulated = false;
            //collision.transform.parent.GetComponent<Character>().isOnStickPlatform++;
            //if (!collision.transform.parent.GetComponent<Character>().enabled)
            //{

            //    Destroy(collision.transform.parent.GetComponent<Rigidbody2D>());
            //}
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision && collision.transform.parent&& collision.transform.parent.parent!=null && ( collision.tag == "GroundCheck" || collision.tag == "Cube"))
        {
            if (TriggerList.Contains(collision))
            {
                TriggerList.Remove(collision);
                if (!collision.transform.parent.gameObject.active)
                {
                    return;
                }
                    if (TriggerList.Count > 0)
                    {

                        collision.transform.parent.parent = TriggerList[0].transform;
                    }
                    else
                    {
                        collision.transform.parent.parent = null;

                    }
                
            }
            //collision.transform.parent.GetComponent<Character>().isOnStickPlatform--;
        }
    }
}
