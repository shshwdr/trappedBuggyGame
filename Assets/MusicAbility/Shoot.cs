using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour,Ability
{
    public GameObject bullet;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        EventPool.OptIn< Vector3[]>("drawLine", drawline);
        EventPool.OptIn("fingerUp", fingerUp);
        EventPool.OptIn("fingerDown", fingerDown);
    }
    void fingerUp()
    {
        audio.Stop();

    }
    void fingerDown()
    {
        audio.Play();

    }
    public void activate(bool isActive)
    {
        if (!isActive)
        {
            var lineRenderer = GetComponentInChildren<LineRenderer>();
            lineRenderer.positionCount = 0;
            //GetComponentInChildren<LineRenderer>().SetPositions(new Vector3[] { });
        }
    }

    void drawline(Vector3[] points)
    {
        if (!gameObject.active)
        {
            return;
        }
        foreach(var p in points)
        {
            var go = Instantiate(bullet, transform.position, Quaternion.identity);
            go.GetComponent<Bullet>().init((p - transform.position).normalized);
        }
        SFXManager.Instance.playComposerShoot();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
