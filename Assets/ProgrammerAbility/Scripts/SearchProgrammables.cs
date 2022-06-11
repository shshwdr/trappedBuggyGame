using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchProgrammables : MonoBehaviour
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
        foreach(Programmable p in programmables)
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
}
