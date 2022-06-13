using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopProgrammable : Programmable
{
    protected int currentIndex = 0;
    public int maxIndex = 3;

    public string loopText = "Rotate Right";
    public override void programmerChange()
    {
        currentIndex++;
        Debug.Log("add current index to " + currentIndex);
        if(currentIndex > maxIndex)
        {
            currentIndex = 0;
        }
        turnOnByProgrammer();
    }

    public override void turnOnByProgrammer()
    {
        isControlledByProgrammer = true;
       // if (!isTurnedOn)
        {
            startTurningOn();
            //isTurnedOn = true;
        }
        //updateText();
    }

    public override void updateText()
    {
        turnOnLabel.text = loopText;
    }
}
