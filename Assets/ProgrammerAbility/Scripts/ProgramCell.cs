using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramCell : MonoBehaviour
{
    Button button;
    public bool isUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponentInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
