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
    public string notControlString = "Off";


    public bool isControlledByProgrammer = false;
    public bool programmerTurnedOn = false;

    ProgramCell programCell;
    TMP_Text turnOnLabel;

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
    public virtual void startTurningOn() { }
    public virtual void startTurningOff() { }
    public void turnOnByProgrammer()
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

    public void updateText()
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
    }

    public virtual void programmerChange()
    {

    }
}