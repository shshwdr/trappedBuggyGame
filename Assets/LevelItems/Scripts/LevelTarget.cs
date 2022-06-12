using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTarget : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("win");


            Physics2D.gravity = new Vector2(0, -25f);

            GameManager.Instance.nextLevel();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
