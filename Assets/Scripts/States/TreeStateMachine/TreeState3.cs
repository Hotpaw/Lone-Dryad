using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeState3 : State
{
    public static TreeState3 INSTANCE;
    bool once;
    public int numberOfCrystallPieces;
    public int maxCrystals;
    public GameObject waterPosition;
    public GameObject playerPosition;
    public GardenGnome gardenGnome;
    public bool trigger1;
    public float checkDist;

    public void Start()
    {
        GameValueManager.INSTANCE.progressActive = false;
        INSTANCE = this;        
    }
    private void Update()
    {
        if (!trigger1)
        {            
            checkDist = Vector2.Distance(waterPosition.transform.position, playerPosition.transform.position);
            if (checkDist < 1)
            {
                if (!once)
                {
                    gardenGnome.SpookedGnome();
                    once = true;
                }
                StartCoroutine(YieldTrigger());
            }
        }
        if(numberOfCrystallPieces == 5)
        {
            GameValueManager.INSTANCE.progressActive = true;
        }        
        
    }
    public IEnumerator YieldTrigger()
    {
        yield return new WaitForSeconds(1);
        trigger1 = true;
    }
    public override State RunCurrentState()
    {
        return this;
    }

}