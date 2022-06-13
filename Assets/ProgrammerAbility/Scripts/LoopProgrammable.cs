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
        if(currentIndex == maxIndex)
        {
            currentIndex = 0;
        }
        turnOnByProgrammer();
    }


    public override void updateText()
    {
        turnOnLabel.text = loopText;
    }
}
