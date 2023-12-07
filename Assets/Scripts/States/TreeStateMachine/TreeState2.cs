using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState2 : State
{
    public static TreeState2 INSTANCE;
    bool once;

    public void Start()
    {
        if(GameValueManager.INSTANCE.treeLevel == 2)
        {
            FindAnyObjectByType<Movement>().isCrawling = false;
            FindAnyObjectByType<Movement>().IncreaseSpeed();
            FindAnyObjectByType<TreeScript>().GetComponent<Health>().HealToMax();
            DistanceChecker[] checkerfs = FindObjectsOfType<DistanceChecker>();
            foreach(DistanceChecker checker in checkerfs)
            {
                checker.enabled = false;
            }
        }
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public override State RunCurrentState()
    {
        return this;
    }
}
