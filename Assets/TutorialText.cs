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
        {"move tutorial", "Move close to buttons and click the button to turn them off" },
        {"artist tutorial", "Move close to buttons and click the button to turn them off" },
        {"switch character", "Q or E to switch between different character" },
        {"coder tutorial", "Move Flavedo close to buttons and click the buttons to turn them off" },

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
