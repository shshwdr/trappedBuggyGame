using Cinemachine;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    PlayerMovement[] playerMovements;
    CinemachineVirtualCamera camera;
    int currentIndex = 0;

    public PlayerMovement currentPlayer { get { return playerMovements[currentIndex]; } }

    public void startLevel()
    {

        playerMovements = GameObject.FindObjectsOfType<PlayerMovement>();
        camera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        camera.Follow = playerMovements[currentIndex].cameraFollow;
        playerMovements[currentIndex].enablePlayer();
        EventPool.Trigger("updateCharacter");
    }
    // Start is called before the first frame update
    void Start()
    {


        EventPool.OptIn<HPObject>("die", CharacterDie);
    }

    void CharacterDie(HPObject ob)
    {
        if(ob == playerMovements[currentIndex].GetComponent<HPObject>())
        {
            if (!hasAliveCharacter())
            {
                Debug.Log("gameover");

                GameManager.Instance.restart();
                return;
            }
            nextCharacter();
        }
    }

    bool hasAliveCharacter()
    {
        playerMovements = GameObject.FindObjectsOfType<PlayerMovement>();
        foreach (var ch in playerMovements)
        {
            if (ch && ch.GetComponent<HPObject>().isAlive)
            {
                return true;
            }
        }
        return false;
    }

    void nextCharacter()
    {
        if (!hasAliveCharacter())
        {
            return;
        }
        playerMovements[currentIndex].disablePlayer();
        currentIndex++;
        if (currentIndex >= playerMovements.Length)
        {
            currentIndex = 0;
        }
        while (playerMovements[currentIndex] == null || playerMovements[currentIndex].GetComponent<HPObject>() == null ||  !playerMovements[currentIndex].GetComponent<HPObject>().isAlive)
        {
            currentIndex++;
            if (currentIndex >= playerMovements.Length)
            {
                currentIndex = 0;
            }

        }
        playerMovements[currentIndex].enablePlayer();
        camera.Follow = playerMovements[currentIndex].cameraFollow;
        EventPool.Trigger("updateCharacter");
    }

    void prevCharacter()
    {
        if (!hasAliveCharacter())
        {
            return;
        }
        playerMovements[currentIndex].disablePlayer();
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = playerMovements.Length - 1;
        }
        while (playerMovements[currentIndex] == null || playerMovements[currentIndex].GetComponent<HPObject>() == null ||  !playerMovements[currentIndex].GetComponent<HPObject>().isAlive)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = playerMovements.Length - 1;
            }
        }

        playerMovements[currentIndex].enablePlayer();
        camera.Follow = playerMovements[currentIndex].cameraFollow;
        EventPool.Trigger("updateCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hasAliveCharacter())
            {
                return;
            }
            nextCharacter();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!hasAliveCharacter())
            {
                return;
            }
            prevCharacter();
        }

    }
}
