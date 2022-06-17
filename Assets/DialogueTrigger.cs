using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<GameObject> enableItems;
    // Start is called before the first frame update
    bool isEnabled;
    void Start()
    {
        EventPool.OptIn("DialogueFinished", dialogueFinished);
    }

    void dialogueFinished()
    {
        if (isEnabled)
        {
            foreach(var c in enableItems)
            {
                c.SetActive(true);
            }
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Composer")
        {
            GetComponent<DialogueSystemTrigger>().OnUse();
        }
        isEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
