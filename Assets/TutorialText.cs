using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    TMP_Text label;
    public string textName;
    static Dictionary<string, string> texts = new Dictionary<string, string>
    {
        {"move tutorial", "AWSD to move around\nSpace to jump" },
        {"artist tutorial", "Draw a circle by mouse to create a cube\nYou can only create in range " },
        {"switch character", "Q or E to switch between different characters" },
        {"multiple finish", "You can finish level along, or with multiple characters arriving the target" },
        {"coder tutorial", "Move Flavedo close to buttons and click the buttons to turn them off" },
        {"composer tutorial", "Switch to Kon and click or drag to shoot. You need to keep shooting to keep the button on." },
        {"shoot character", "Composer can shoot to push others" },

    };

    // Start is called before the first frame update
    void Start()
    {
        label = GetComponentInChildren<TMP_Text>();
        if (texts.ContainsKey(textName))
        {

            label.text = texts[textName];
        }
        else
        {
            Debug.LogError("no text name " + textName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
