using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour, Ability
{
    GameObject cubeGenerated;
    public GameObject cubePrefab;
    public float drawDistance = 4f;
    public GameObject range;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        EventPool.OptIn<Vector3[]>("drawLine", draw);
        EventPool.OptIn("fingerUp", fingerUp);
        EventPool.OptIn("fingerDown", fingerDown);
        fingerUp(); 
    }

    void fingerUp()
    {
        audio.Stop();
        range.SetActive(false);

    }
    void fingerDown()
    {
        audio.Play();
        range.SetActive(true);

    }

    void draw(Vector3[] positions)
    {

        if (!gameObject.active)
        {
            return;
        }
        if(positions.Length <= 3)
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

        var dir = (center - transform.position).normalized;
        var distance = (center - transform.position).magnitude;
        if (distance > drawDistance)
        {
            distance = drawDistance;
        }

        var finalPosition = transform.position + dir * distance;

        if (cubeGenerated)
        {
            Destroy(cubeGenerated);
        }
        cubeGenerated = Instantiate(cubePrefab, finalPosition, Quaternion.identity);
        SFXManager.Instance. playCubeAppear();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activate(bool isActive)
    {
        if (!isActive)
        {
            //GetComponentInChildren<LineRenderer>().SetPositions(new Vector3[] { });
            fingerUp();
        }
    }
}
