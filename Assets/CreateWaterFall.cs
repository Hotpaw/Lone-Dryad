using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaterFall : MonoBehaviour
{
    public Transform firstFallPosition;
    public GameObject waterfall;
    public int waterfallWidth;

    private void Start()
    {
        float lineWithMultiplier = firstFallPosition.GetComponent<LineRenderer>().startWidth;
        for (int i = 0; i < waterfallWidth; i++)
        {
            GameObject WaterfallClone = Instantiate(waterfall, firstFallPosition);
            WaterfallClone.transform.position = firstFallPosition.position + new Vector3(lineWithMultiplier * i,0,0);
        }
      
        
    }
}
