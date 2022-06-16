using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUtils : Singleton<DialogueUtils>
{

    public bool isInDialogue;
    // Start is called before the first frame update
    public void StartDialogue()
    {
        isInDialogue = true;
    }

    // Update is called once per frame
    public void StopDialogue()
    {
        isInDialogue = false;
    }
}
