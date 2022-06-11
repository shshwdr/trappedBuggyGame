using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour,IReactItem
{
    public GameObject actualItem;
    float turnOffTime = 0.1f;
    public void react(bool isOn)
    {
        if (isOn)
        {

            actualItem.transform.DOLocalMoveY(5, turnOffTime);
        }
        else
        {

            actualItem.transform.DOLocalMoveY(0, turnOffTime);
        }
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
