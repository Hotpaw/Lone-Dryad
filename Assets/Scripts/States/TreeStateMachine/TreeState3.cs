using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeState3 : State
{
    public static TreeState3 INSTANCE;
    public bool once;
    public int numberOfCrystallPieces;
    public int maxCrystals;
    public GameObject waterPosition;
    public GameObject playerPosition;
    public GameObject trigger2Position;
    public GardenGnome1 gardenGnome;
    public GardenGnome2 gardenGnome2;
    public bool trigger1;
    public bool trigger2;
    public bool trigger3;
    public float checkDist;
    public float checkDist2;

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
            if (checkDist < 4)
            {
                if (!once)
                {
                    gardenGnome.SpookedGnome();
                    once = true;
                    StartCoroutine(YieldTrigger());
                }
            }
        }
        else if (!trigger2)
        {
            checkDist2 = Vector2.Distance(trigger2Position.transform.position, playerPosition.transform.position);            
            if (checkDist2 < 1.2f)
            {
                if (!once)
                {                    
                    once = true;
                    trigger2 = true;
                }
                StartCoroutine(YieldTrigger());
            }
        }        
        if(GameValueManager.INSTANCE.numberOfCrystallPieces > 5 && !trigger3) 
        {
            GameValueManager.INSTANCE.stormStrenght +=2;
            trigger3 = true;
        }
        
    }
    public IEnumerator YieldTrigger()
    {
        yield return new WaitForSeconds(1);

        if (!trigger1)        
            trigger1 = true;        
        else        
            trigger2 = true;

        once = false;

    }
    public override State RunCurrentState()
    {
        return this;
    }

}