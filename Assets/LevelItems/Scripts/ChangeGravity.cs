using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour, IReactItem
{
    public void react(bool isOn)
    {
        SFXManager.Instance. playGravityChange();
        if (isOn)
        {
            Physics2D.gravity = new Vector2(0, 25f);
        }
        else
        {

            Physics2D.gravity = new Vector2(0, -25f);
        }
    }
}
