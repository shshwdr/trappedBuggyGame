using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using tw

public class PressableButton : Programmable
{
    enum States { off, turningOn, on, waitToTurnOff, turningOff }

    States state;
    public GameObject reactItem;
    public float turnOffTime = 0.1f;
    float turnOnTimer;

    int collideCount = 0;

    public float waitTime = 5f;
    float waitTimer;

    public float turnOnTime = 0.1f;
    float turnOffTimer;
    public GameObject buttonObject;





    public override void programmerChange()
    {
        if (!isControlledByProgrammer)
        {

            turnOnByProgrammer();
        }else if (programmerTurnedOn)
        {

            turnOffByProgrammer();
        }
        else
        {
            stopControll();
        }
    }
    public override void stopControll()
    {

        base.stopControll();
        if (isTurnedOn && collideCount == 0)
        {
            isTurnedOn = false;
            state = States.waitToTurnOff;
        }
        if(!isTurnedOn && collideCount > 0)
        {
            isTurnedOn = true;
            startTurningOn();
        }
    }

    public override void startTurningOff()
    {

        state = States.turningOff;

        transform.DOKill();

        buttonObject.transform.DOScaleY(1, turnOffTime);
        reactItem.GetComponent<IReactItem>().react(false);
    }


    public override void startTurningOn()
    {

        state = States.turningOn;


        transform.DOKill();
        turnOnTimer = 0;
        waitTimer = 0;
        turnOffTimer = 0;
        buttonObject.transform.DOScaleY(0, turnOnTime);

        reactItem.GetComponent<IReactItem>().react(true);
        //reactItem.GetComponent<IReactItem>().react(isTurnedOn);
    }

    public void turnOn()
    {
        isTurnedOn = true;

        startTurningOn();

        updateText();
    }

    public void turnOff()
    {

        isTurnedOn = false;

        switch (state)
        {
            case States.on:
            case States.turningOn:
                state = States.waitToTurnOff;
                break;
            default:
                Debug.LogError("wrong state");
                break;
        }

        //state = States.turningOff;


        //DOTween.KillAll();
        //buttonObject.transform.DOScaleY(1, turnOffTime);
        //reactItem.GetComponent<IReactItem>().react(isTurnedOn);


    }

    //public override void toggleTurnOn()
    //{
    //    isTurnedOn = !isTurnedOn;
    //    if (isTurnedOn)
    //    {

    //    }
    //    switch (state) {
    //        case States.off:
    //            //when it was off, start to turn on
    //            state = States.turningOn;
    //            isTurnedOn = true;


    //            DOTween.KillAll();
    //            turnOnTimer = 0;
    //            buttonObject.transform.DOScaleY(0, turnOnTime);
    //            reactItem.GetComponent<IReactItem>().react(isTurnedOn);


    //            break;
    //        case States.turningOn:


    //    }


    //    updateText();
    //}

    private void Update()
    {
        switch (state)
        {
            case States.off:
                break;
            case States.turningOn:
                if (turnOnTimer < turnOnTime)
                {
                    turnOnTimer += Time.deltaTime;
                }
                else
                {
                    state = States.on;
                }
                break;
            case States.turningOff:
                if (turnOffTimer < turnOffTime)
                {
                    turnOffTimer += Time.deltaTime;
                }
                else
                {
                    state = States.off;
                }
                break;
            case States.waitToTurnOff:
                if (waitTimer < waitTime)
                {
                    waitTimer += Time.deltaTime;
                }
                else
                {
                    startTurningOff();
                }
                break;

        }


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Cube" || collision.tag == "Bullet")
        {
            collideCount++;
            Debug.Log("collide count " + collideCount);
            if (!(isControlledByProgrammer && !programmerTurnedOn)) { 
                if (!isTurnedOn)
                {
                    turnOn();
                }
        }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player" || collision.tag == "Cube" || collision.tag == "Bullet")
        {
            collideCount--;
            Debug.Log("collide count " + collideCount);
            if (collideCount == 0 && !(isControlledByProgrammer && programmerTurnedOn))
            {
                if (isTurnedOn)
                {
                    turnOff();
                }
            }
        }
    }
}
