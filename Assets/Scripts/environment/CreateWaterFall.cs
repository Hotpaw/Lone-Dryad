using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaterFall : MonoBehaviour
{
    public Transform firstFallPosition;
    public GameObject waterfall;
    public float waterFallSpeed;
    public float waterFallLength;
    public int waterAmount;
    public float waterFallWidth;
    List<GameObject> waterList = new();
    float lineWithMultiplier;

    private void Start()
    {
        firstFallPosition.GetComponent<LineRenderer>().startWidth = waterFallWidth;
        firstFallPosition.GetComponent<WaterController>().fallSpeed = waterFallSpeed;
        firstFallPosition.GetComponent<WaterController>().maxLenght = waterFallLength;
        lineWithMultiplier = firstFallPosition.GetComponent<LineRenderer>().startWidth;
        waterList.Add(firstFallPosition.gameObject);
        for (int i = 0; i < waterAmount; i++)
        {
            GameObject WaterfallClone = Instantiate(waterfall, firstFallPosition);
            waterList.Add(WaterfallClone);
            WaterfallClone.GetComponent<WaterController>().fallSpeed = firstFallPosition.GetComponent<WaterController>().fallSpeed;
            WaterfallClone.GetComponent<WaterController>().maxLenght = firstFallPosition.GetComponent<WaterController>().maxLenght;
            WaterfallClone.transform.position = firstFallPosition.position + new Vector3(lineWithMultiplier * i,0,0);
            WaterfallClone.GetComponent<LineRenderer>().startWidth = lineWithMultiplier;
        }
      
        
    }
    private void Update()
    {
        ChangeWaterFallValues();
    }
    public void ChangeWaterFallValues()
    {
        foreach (GameObject WaterfallClone in waterList)
        {
            WaterfallClone.GetComponent<WaterController>().fallSpeed = waterFallSpeed;
            WaterfallClone.GetComponent<WaterController>().maxLenght = waterFallLength;
   
        }
    }
}
