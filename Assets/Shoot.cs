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

    }
    // Update is called once per frame
    void Update()
    {
    }
}
