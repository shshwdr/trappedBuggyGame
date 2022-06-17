using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTarget : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Composer")
        {
            Debug.Log("win");


            Physics2D.gravity = new Vector2(0, -25f);
            SFXManager.Instance. playLevelComplete();
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
