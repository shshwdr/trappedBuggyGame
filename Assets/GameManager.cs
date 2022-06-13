using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void nextLevel()
    {

        Physics2D.gravity = new Vector2(0, -25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void prevLevel()
    {

        Physics2D.gravity = new Vector2(0, -25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void restart()
    {

        Physics2D.gravity = new Vector2(0, -25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            nextLevel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            prevLevel();
        }
    }
}
