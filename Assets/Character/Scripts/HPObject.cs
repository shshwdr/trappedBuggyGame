﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObject : MonoBehaviour
{
    protected AudioSource audiosource;
    public bool isAlive = true;
    public int maxHP = 1;
    public int getCurrentHp() { return hp; }
    int hp;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        hp = maxHP;
        audiosource = GetComponent<AudioSource>();
    }

    public void beAttacked(int damage = 1)
    {
        if (!isAlive)
        {
            return;
        }
        hp -= damage;
        if (hp <= 0)
        {
            die();
        }
    }

    public virtual void die()
    {
        if (!isAlive)
        {
            return;
        }
        isAlive = false;
        Destroy(gameObject);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
