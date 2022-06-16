using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Programmable : MonoBehaviour
{
    public bool isTurnedOn = false;

    public string turnOnTrueString = "On";
    public string turnOnFalseString = "Off";
    public string notControlString = "Not Control";


    public bool isControlledByProgrammer = false;
    public bool programmerTurnedOn = false;

    ProgramCell programCell;
    protected TMP_Text turnOnLabel;

    protected enum States { off, turningOn, on, waitToTurnOff, turningOff }

    protected States state;
    public float turnOffTime = 0.1f;
    protected float turnOnTimer;

    public float waitTime = 5f;
    protected float waitTimer;

    public float turnOnTime = 0.1f;
    protected float turnOffTimer;

    protected Canvas canvas;

    public virtual void turnOn()
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
    }



    protected virtual void Update()
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

    public virtual void programmerChange()
    {
        if (!isControlledByProgrammer)
        {

            turnOnByProgrammer();
        }
        else if (programmerTurnedOn)
        {

            turnOffByProgrammer();
        }
        else
        {
            stopControll();
        }
    }

    public virtual void toggleTurnOn()
    {
        isTurnedOn = !isTurnedOn;
        updateText();
    }

    public virtual void stopControll()
    {

        isControlledByProgrammer = false;
        programmerTurnedOn = false;

        updateText();
    }
    public virtual void startTurningOn()
    {
        state = States.turningOn;
        turnOnTimer = 0;
        waitTimer = 0;
        turnOffTimer = 0;
    }
    public virtual void startTurningOff()
    {
        state = States.turningOff;
    }
    public virtual void turnOnByProgrammer()
    {
        isControlledByProgrammer = true;
        programmerTurnedOn = true;
        if (!isTurnedOn)
        {
            startTurningOn();
            isTurnedOn = true;
        }
        updateText();
    }

    public void turnOffByProgrammer()
    {
        isControlledByProgrammer = true;
        programmerTurnedOn = false;
        if (isTurnedOn)
        {
            startTurningOff();
            isTurnedOn = false;
        }
        updateText();
    }


    public void setVisible(bool isVisible)
    {

        GetComponentInChildren<ProgramMenu>(true).gameObject.SetActive(isVisible);
    }

    public void activate(bool isActive)
    {
        setVisible(isActive);
        if (!isActive)
        {

            if (isControlledByProgrammer)
            {
                stopControll();
            }
        }
    }

    public virtual void updateText()
    {
        if (isControlledByProgrammer)
        {
            if (isTurnedOn)
            {
                turnOnLabel.text = turnOnTrueString;
            }
            else
            {

                turnOnLabel.text = turnOnFalseString;
            }
        }
        else
        {

            turnOnLabel.text = notControlString;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        programCell = GetComponentInChildren<ProgramMenu>(true).addCell();
        turnOnLabel = programCell.GetComponentInChildren<TMP_Text>();
        var turnOnButton = programCell.GetComponentInChildren<Button>();
        turnOnButton.onClick.AddListener(programmerChange);
        updateText();
        canvas = GetComponent<Canvas>();
    }

    protected void updateCanvasRotation()
    {

        canvas.transform.rotation = Quaternion.Inverse(transform.rotation);
    }

}