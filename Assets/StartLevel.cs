using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.startLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
