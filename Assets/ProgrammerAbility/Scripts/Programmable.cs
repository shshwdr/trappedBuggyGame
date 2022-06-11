using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Programmable:MonoBehaviour
{
    public bool isTurnedOn = false;

    public string turnOnTrueString = "On";
    public string turnOnFalseString = "Off";


    ProgramCell programCell;
    TMP_Text turnOnLabel;

    public virtual void toggleTurnOn()
    {
        isTurnedOn = !isTurnedOn;
        updateText();
    }

    public void activate(bool isActive)
    {
        GetComponentInChildren<ProgramMenu>(true).gameObject.SetActive(isActive);
    }

    public void updateText()
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

    // Start is called before the first frame update
    void Start()
    {
        programCell = GetComponentInChildren<ProgramMenu>(true).addCell();
        turnOnLabel = programCell.GetComponentInChildren<TMP_Text>();
        var turnOnButton = programCell.GetComponentInChildren<Button>();
        turnOnButton.onClick.AddListener(toggleTurnOn);
        updateText();
    }
}