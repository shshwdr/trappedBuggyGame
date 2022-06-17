using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSearchProgrammables : MonoBehaviour
{
    public SearchProgrammables search; 
    void Update()
    {
        search.updateProgrammables();
    }
}
