using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchProgrammables : MonoBehaviour, Ability
{
    Programmable[] programmables;
    public float detectDistance = 1;
    public GameObject range;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
        programmables = GameObject.FindObjectsOfType<Programmable>(true);
        EventPool.OptIn("fingerUp", fingerUp);
        EventPool.OptIn("fingerDown", fingerDown);
        fingerUp();
    }
    void fingerUp()
    {
        if (!gameObject.active)
        {
            return;
        }
        range.SetActive(false);
        animator.SetBool("isAction", false);

    }
    void fingerDown()
    {
        if (!gameObject.active)
        {
            return;
        }
        range.SetActive(true);
        animator.SetBool("isAction", true);

    }


    public void updateProgrammables()
    {

        if (programmables == null)
        {

            programmables = GameObject.FindObjectsOfType<Programmable>(true);
        }

        foreach (Programmable p in programmables)
        {
            if ((p.transform.position - transform.position).magnitude < detectDistance)
            {
                if (this.isActiveAndEnabled)
                {
                    p.activate(true);
                }
            }
            else
            {

                p.activate(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        updateProgrammables();
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

        if (!isActive)
        {
            fingerUp();
            //GetComponentInChildren<LineRenderer>().SetPositions(new Vector3[] { });
        }
    }
}
