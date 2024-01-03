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
    public SpriteMask spriteMask; // Assuming you have a SpriteMask in the scene

    List<GameObject> waterList = new List<GameObject>();
    float lineWidthMultiplier;
    private int previousWaterAmount;

    [Header("Waterfall Audio")]
    public GameObject waterAudio;

    private void Start()
    {
        InitializeFirstWaterfall();
        previousWaterAmount = waterAmount;
        CreateInitialWaterfalls();
    }

    private void Update()
    {
        if (waterAmount != previousWaterAmount)
        {
            RecreateWaterfalls();
            previousWaterAmount = waterAmount;
        }
        else
        {
            ChangeWaterFallValues();
        }
    }

    private void InitializeFirstWaterfall()
    {
        LineRenderer firstLineRenderer = firstFallPosition.GetComponent<LineRenderer>();
        firstLineRenderer.startWidth = waterFallWidth;
        firstLineRenderer.endWidth = waterFallWidth;
        lineWidthMultiplier = firstLineRenderer.startWidth;

        if (spriteMask != null)
        {
            firstLineRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }

        WaterController firstWaterController = firstFallPosition.GetComponent<WaterController>();
        firstWaterController.fallSpeed = waterFallSpeed;
        firstWaterController.maxLenght = waterFallLength;

        waterList.Add(firstFallPosition.gameObject);
    }

    private void CreateInitialWaterfalls()
    {
        int postProcessingLayer = LayerMask.NameToLayer("Default"); // Change this to postprossesing if you want

        for (int i = 1; i < waterAmount; i++)
        {
            GameObject WaterfallClone = Instantiate(waterfall, firstFallPosition.position + new Vector3(lineWidthMultiplier * i, 0, 0), Quaternion.identity, firstFallPosition.parent);
            waterList.Add(WaterfallClone);

            // Set the instantiated object to the PostProcessing layer
            WaterfallClone.layer = postProcessingLayer;

            LineRenderer lineRenderer = WaterfallClone.GetComponent<LineRenderer>();
            lineRenderer.startWidth = lineWidthMultiplier;
            lineRenderer.endWidth = lineWidthMultiplier;
            if (spriteMask != null)
            {
                lineRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            }

            WaterController waterController = WaterfallClone.GetComponent<WaterController>();
            waterController.fallSpeed = waterFallSpeed;
            waterController.maxLenght = waterFallLength;
        }
    }

    private void RecreateWaterfalls()
    {
        foreach (GameObject WaterfallClone in waterList)
        {
            if (WaterfallClone != firstFallPosition.gameObject)
            {
                Destroy(WaterfallClone);
            }
        }
        waterList.Clear();
        waterList.Add(firstFallPosition.gameObject);
        CreateInitialWaterfalls();
    }

    private void ChangeWaterFallValues()
    {
        foreach (GameObject WaterfallClone in waterList)
        {
            LineRenderer lineRenderer = WaterfallClone.GetComponent<LineRenderer>();
            lineRenderer.startWidth = waterFallWidth;
            lineRenderer.endWidth = waterFallWidth;

            WaterController waterController = WaterfallClone.GetComponent<WaterController>();
            waterController.fallSpeed = waterFallSpeed;
            waterController.maxLenght = waterFallLength;
        }
    }
}