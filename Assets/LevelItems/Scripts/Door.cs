using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IReactItem
{
    public GameObject actualItem;
    public void react(bool isOn)
    {
        
        actualItem.SetActive(!isOn);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
