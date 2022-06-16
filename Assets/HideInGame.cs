using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInGame : MonoBehaviour
{
    public bool hideWholeObject = false;
    // Start is called before the first frame update
    void Start()
    {
        if (hideWholeObject)
        {
            gameObject.SetActive(false);
        }
        else
        {

            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
