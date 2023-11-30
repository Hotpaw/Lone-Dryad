using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : InteractableObject
{
    public static Water INSTANCE;
    public float waterAmount;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public override void Interact()
    {
        PopUpText.INSTANCE.PopUpMessage("Got water", Color.blue);
        GameValueManager.INSTANCE.carryingWater += waterAmount;
        waterAmount = 0;
    }
}