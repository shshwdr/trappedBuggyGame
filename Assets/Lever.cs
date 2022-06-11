using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lever : Programmable
{

    public GameObject reactItem;

    public override void toggleTurnOn()
    {
        base.toggleTurnOn();
        reactItem.GetComponent<IReactItem>(). react(isTurnedOn);
    }

}
