using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Sprite icon;
    public PhysicsMaterial2D disabledMaterial;
    Rigidbody2D rb;
    public int isOnStickPlatform = 0;

    public bool enabled = false;

    public void enablePlayer()
    {
        if(GetComponent<Rigidbody2D>() == null)
        {
            rb = gameObject. AddComponent<Rigidbody2D>();
            rb.freezeRotation = true;
        }
        enabled = true;
       // rb.sharedMaterial = null;
    }
    public void disablePlayer()
    {
        if (isOnStickPlatform>0)
        {
            Destroy(rb);
        }

        enabled = false;
        //rb.sharedMaterial = disabledMaterial;
    }
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
