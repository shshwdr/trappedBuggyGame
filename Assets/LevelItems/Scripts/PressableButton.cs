using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using tw

public class PressableButton : OnOffProgrammable
{

    public GameObject reactItem;

    int collideCount = 0;
   
    public GameObject buttonObject;


    public override void stopControll()
    {

        base.stopControll();
        if (isTurnedOn && collideCount == 0)
        {
            isTurnedOn = false;
            state = States.waitToTurnOff;
            return;
        }
        if(!isTurnedOn && collideCount > 0)
        {
            isTurnedOn = true;
            startTurningOn();
        }
    }

    public override void startTurningOff()
    {
        base.startTurningOff();

        transform.DOKill();

        buttonObject.transform.DOScaleY(1, turnOffTime);
        reactItem.GetComponent<IReactItem>().react(false);
    }


    public override void startTurningOn()
    {
        base.startTurningOn();

        transform.DOKill();
        buttonObject.transform.DOScaleY(0, turnOnTime);

        reactItem.GetComponent<IReactItem>().react(true);
    }






    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Cube" || collision.tag == "Bullet" || collision.tag == "EnemyBullet")
        {
            collideCount++;
            Debug.Log("collide count " + collideCount + collision.gameObject.name);
            if (!(isControlledByProgrammer && !programmerTurnedOn)) { 
                if (!isTurnedOn)
                {
                    turnOn();
                }
        }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player" || collision.tag == "Cube" || collision.tag == "Bullet" || collision.tag == "EnemyBullet")
        {
            collideCount--;
            Debug.Log("collide count " + collideCount);
            if (collideCount == 0 && !(isControlledByProgrammer && programmerTurnedOn))
            {
                if (isTurnedOn)
                {
                    turnOff();
                }
            }
        }
    }
}
