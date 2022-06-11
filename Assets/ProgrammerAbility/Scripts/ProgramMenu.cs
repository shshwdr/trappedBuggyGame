using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgramMenu : MonoBehaviour
{
    ProgramCell[] cells;
    // Start is called before the first frame update
    void Awake()
    {
        cells = GetComponentsInChildren<ProgramCell>();
        foreach(var c in cells)
        {
            c.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
    public ProgramCell addCell()
    {
        foreach(var c in cells)
        {
            if (!c.gameObject.active)
            {
                c.gameObject.SetActive(true);
                return c;
            }
        }
        Debug.LogError("not enough cell");
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
