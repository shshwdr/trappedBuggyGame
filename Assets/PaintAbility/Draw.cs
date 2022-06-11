using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    GameObject cubeGenerated;
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn<Vector3[]>("drawLine", draw);
    }

    void draw(Vector3[] positions)
    {

        if (!gameObject.active)
        {
            return;
        }
        //Debug.Log("positions:");
        //foreach(var v in positions)
        //{
        //    Debug.Log(v);
        //}

        Vector3 center = positions[0];
        for (int i = 1; i < positions.Length; i++)
        {
            var position = positions[i];
            center += position;

        }
        center /= positions.Length;

        float maxRadius = 0;
        for (int i = 0; i < positions.Length; i++)
        {
            var position = positions[i];
            var radius = (position - center).magnitude;
            maxRadius = Mathf.Max(radius, maxRadius);

        }


        if (cubeGenerated)
        {
            Destroy(cubeGenerated);
        }
        cubeGenerated = Instantiate(cubePrefab, center, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
