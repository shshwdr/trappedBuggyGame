using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    PlayerMovement[] playerMovements;
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerMovements = GameObject.FindObjectsOfType<PlayerMovement>();
        playerMovements[currentIndex].isControlling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerMovements[currentIndex].isControlling = false;
            currentIndex++;
            if (currentIndex >= playerMovements.Length)
            {
                currentIndex = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerMovements[currentIndex].isControlling = false;
            currentIndex--;
            if (currentIndex <0)
            {
                currentIndex = playerMovements.Length-1;
            }
        }

        playerMovements[currentIndex].isControlling = true;
    }
}
