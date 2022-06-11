using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        EventPool.OptIn< Vector3[]>("drawLine", drawline);
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
    }
    // Update is called once per frame
    void Update()
    {
    }
}
