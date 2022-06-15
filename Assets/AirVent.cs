using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : MonoBehaviour, IReactItem
{
    public GameObject effector;
    float turnOffTime = 0.1f;
    public bool startState = false;

    private void Start()
    {
        effector.SetActive(false);
    }
    public void react(bool isOn)
    {
        effector.SetActive(isOn);
        //transform.DOKill();
        //if (isOn)
        //{
        //}
        //else
        //{

        //    actualItem.transform.DOLocalMoveY(0, turnOffTime);
        //}
    }
}
