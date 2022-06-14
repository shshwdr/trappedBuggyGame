using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour,IReactItem
{
    public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Rigidbody2D rBody;
    public void react(bool isOn)
    {
        //transform.DOKill();
        //if (isOn)
        //{

        //    actualItem.transform.DOLocalMoveY(5, turnOffTime);
        //}
        //else
        //{

        //    actualItem.transform.DOLocalMoveY(0, turnOffTime);
        //}
        StopAllCoroutines();
        if (isOn)
        {

            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
        else
        {

            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
    }

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
    }

    void Update()
    {
        //if (rBody.position == endPosition)
        //{

        //    StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        //}
        //if (rBody.position == startPosition)
        //{
        //    StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        //}
    }

    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector2 target, float speed)
    {
        Vector2 startPosition = obj.transform.position;
        float time = 0f;

        while (rBody.position != target)
        {
            obj.transform.position = Vector2.Lerp(startPosition, target, (time / Vector2.Distance(startPosition, target)) * speed);
            time += Time.deltaTime;
            yield return null;
        }
    }

    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    col.gameObject.transform.SetParent(gameObject.transform, true);
    //}

    //void OnCollisionExit2D(Collision2D col)
    //{
    //    col.gameObject.transform.parent = null;
    //}
}