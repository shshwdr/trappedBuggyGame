using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiableFunction : OnOffProgrammable
{
    public UnityEvent turnOnFunction;
    public UnityEvent turnOffFunction;
    public override void stopControll()
    {
        base.stopControll();
        if (isTurnedOn)
        {
            isTurnedOn = false;
            state = States.waitToTurnOff;
            return;
        }
        if (!isTurnedOn)
        {
            isTurnedOn = true;
            startTurningOn();
        }
    }
    public override void startTurningOff()
    {
        base.startTurningOff();
        turnOffFunction.Invoke();
    }
    public override void startTurningOn()
    {
        base.startTurningOn();
        turnOnFunction.Invoke();
    }

}
