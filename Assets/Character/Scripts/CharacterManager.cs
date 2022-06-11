using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    PlayerMovement[] playerMovements;
    CinemachineVirtualCamera camera;
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerMovements = GameObject.FindObjectsOfType<PlayerMovement>();
        camera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        camera.Follow = playerMovements[currentIndex].transform;
        playerMovements[currentIndex].enablePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerMovements[currentIndex].disablePlayer();
            currentIndex++;
            if (currentIndex >= playerMovements.Length)
            {
                currentIndex = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerMovements[currentIndex].disablePlayer();
            currentIndex--;
            if (currentIndex <0)
            {
                currentIndex = playerMovements.Length-1;
            }
        }

        playerMovements[currentIndex].enablePlayer();
        camera.Follow = playerMovements[currentIndex].transform;
    }
}
