using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour,IReactItem
{
    public GameObject actualItem;
    public float turnOffTime = 0.1f;

    public float liftUpHeight = 5;
    float originalY;

    public void react(bool isOn)
    {
        SFXManager.Instance. playDoorSlide(isOn);
        transform.DOKill();
        if (isOn)
        {

            actualItem.transform.DOLocalMoveY(originalY+liftUpHeight, turnOffTime);
        }
        else
        {

            actualItem.transform.DOLocalMoveY(originalY, turnOffTime);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        originalY = actualItem.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
