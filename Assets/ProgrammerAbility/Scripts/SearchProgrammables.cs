using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchProgrammables : MonoBehaviour, Ability
{
    Programmable[] programmables;
    public float detectDistance = 1;
    // Start is called before the first frame update
    void Start()
    {
        programmables = GameObject.FindObjectsOfType<Programmable>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (programmables == null)
        {

            programmables = GameObject.FindObjectsOfType<Programmable>(true);
        }
        foreach (Programmable p in programmables)
        {
            if((p.transform.position - transform.position).magnitude < detectDistance)
            {
                p.activate(true);
            }
            else
            {

                p.activate(false);
            }
        }
    }

    public void activate(bool isActive)
    {
        if(programmables == null)
        {

            programmables = GameObject.FindObjectsOfType<Programmable>(true);
        }
        foreach (Programmable p in programmables)
        {
            if ((p.transform.position - transform.position).magnitude < detectDistance)
            {
                p.setVisible(isActive);
            }
        }
    }
}
