using Cinemachine;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    List<PlayerMovement> playerMovements;
    CinemachineVirtualCamera camera;
    int currentIndex = 0;
    public int passedIndex = 0;
    public bool[] finishedState = new bool[3];

    public void finishCharacter(PlayerMovement player)
    {
        var index = playerMovements.IndexOf(player);
        if(finishedState[index] != true)
        {

            finishedState[index] = true;
            passedIndex++;
            EventPool.Trigger("characterTargetChange");
            
        }
    }
    public void leaveCharacter(PlayerMovement player)
    {

        var index = playerMovements.IndexOf(player);
        if (finishedState[index] != false)
        {
            finishedState[index] = false;
            passedIndex--;
            EventPool.Trigger("characterTargetChange");
        }
    }
    public PlayerMovement currentPlayer { get { return playerMovements[currentIndex]; } }

    void updatePlayerMovements()
    {

        playerMovements = new List<PlayerMovement> {
        GameObject.Find("artist")?.GetComponent<PlayerMovement>(),
        GameObject.Find("coder")?.GetComponent<PlayerMovement>(),
        GameObject.Find("composer")?.GetComponent<PlayerMovement>(),
        };
    }

    public void startLevel()
    {
        updatePlayerMovements();
        camera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        camera.Follow = playerMovements[currentIndex].cameraFollow;
        playerMovements[currentIndex].enablePlayer();
        EventPool.Trigger("updateCharacter");
        finishedState = new bool[3];
        EventPool.Trigger("characterTargetChange");
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
        //if()
        updatePlayerMovements();
        foreach (var ch in playerMovements)
        {
            if (ch && ch.isActiveAndEnabled && ch.GetComponent<HPObject>().isAlive)
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
        var originIndex = currentIndex;
        if (playerMovements[currentIndex] && playerMovements[currentIndex].isActiveAndEnabled)
        {

            playerMovements[currentIndex].disablePlayer();
        }
        currentIndex++;
        if (currentIndex >= playerMovements.Count)
        {
            currentIndex = 0;
        }
        while (playerMovements[currentIndex] == null || !playerMovements[currentIndex].isActiveAndEnabled|| playerMovements[currentIndex].GetComponent<HPObject>() == null ||  !playerMovements[currentIndex].GetComponent<HPObject>().isAlive)
        {
            currentIndex++;
            if (currentIndex >= playerMovements.Count)
            {
                currentIndex = 0;
            }

        }


        if (originIndex != currentIndex)
        {

            SFXManager.Instance.playSwitchCharacter(currentIndex);
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
        var originIndex = currentIndex;
        if (playerMovements[currentIndex]&& playerMovements[currentIndex].isActiveAndEnabled)
        {

            playerMovements[currentIndex].disablePlayer();
        }
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = playerMovements.Count - 1;
        }
        while (playerMovements[currentIndex] == null || !playerMovements[currentIndex].isActiveAndEnabled|| playerMovements[currentIndex].GetComponent<HPObject>() == null ||  !playerMovements[currentIndex].GetComponent<HPObject>().isAlive)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = playerMovements.Count - 1;
            }
        }


        if (originIndex != currentIndex)
        {

            SFXManager.Instance.playSwitchCharacter(currentIndex);
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
