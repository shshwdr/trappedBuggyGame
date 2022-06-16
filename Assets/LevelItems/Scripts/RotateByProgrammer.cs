using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByProgrammer : LoopProgrammable
{
    
    public Vector3 rotateDegree = new Vector3(0, 0, 90);
    public override void stopControll()
    {
        base.stopControll();
        //if (isTurnedOn)
        //{
            isTurnedOn = false;
            state = States.waitToTurnOff;
        //    return;
        //}
        //if (!isTurnedOn)
        //{
        //    isTurnedOn = true;
        //    startTurningOn();
        //}
    }
    public override void startTurningOff()
    {
        base.startTurningOff();
        if(currentIndex == 0)
        {
            return;
        }


        Debug.Log("return back with current index" + currentIndex);

        transform.Rotate(rotateDegree * (maxIndex - currentIndex+1));
        updateCanvasRotation();
        currentIndex = 0;
    }
    public override void startTurningOn()
    {
        base.startTurningOn();
        transform.Rotate(rotateDegree);
        updateCanvasRotation();
    }


}
