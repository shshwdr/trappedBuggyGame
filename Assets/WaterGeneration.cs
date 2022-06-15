using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGeneration : MonoBehaviour, IReactItem
{
    public void react(bool isOn)
    {
        isGenerating = !isOn;
    }

    public GameObject waterPrefab;
    public Transform generatePositions;
    public float generateTime = 0.5f;
    float generateTimer = 0;
    bool isGenerating = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGenerating)
        {

            generateTimer += Time.deltaTime;
            if (generateTimer >= generateTime)
            {
                generateTimer = 0;
                for(int i = 0;i< generatePositions.childCount;i++)
                {
                    var p = generatePositions.GetChild(i);
                    Instantiate(waterPrefab, Utils.randomVector3_2d(p.position,0.2f),Quaternion.identity);
                }
            }
        }
    }
}
