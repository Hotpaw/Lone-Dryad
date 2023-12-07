using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class WaterOrb : MonoBehaviour
{
    public TreeScript tree;
    Vector3 followDryadPosition;

    ParticleSystem PS;
    public float wateringCountDown = 10;

    public Vector3 WateringTreePosition;
    public float WateringYOffset;

    //Healing bools
    bool heal1;
    bool heal2;
    bool heal3;
    bool heal4;

    // Start is called before the first frame update
    void Start()
    {        
        PS = this.GetComponentInChildren<ParticleSystem>();
        WateringTreePosition = new Vector2(tree.transform.position.x, tree.transform.position.y + WateringYOffset);        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameValueManager.INSTANCE.addingWater)
        {
            followDryadPosition = GetComponentInParent<Transform>().position;
            transform.position = Vector3.MoveTowards(transform.position, followDryadPosition, 0.1f);
            heal1 = false;
            heal2 = false;
            heal3 = false; 
            heal4 = false;
        }
        if (GameValueManager.INSTANCE.carryingWater > 0)
        {
            var subEmitters = PS.subEmitters;
            subEmitters.SetSubEmitterEmitProbability(0, 0.02f);
            var emission = PS.emission;
            emission.rateOverTime = 100;            
            if (GameValueManager.INSTANCE.addingWater)
            {
                transform.position = Vector3.MoveTowards(transform.position, WateringTreePosition, 0.1f);
                if (transform.position == WateringTreePosition)
                {                    
                    subEmitters.SetSubEmitterEmitProbability(0, 1f);
                    wateringCountDown -= (2 *Time.deltaTime);                    

                    if(wateringCountDown >= 0 && wateringCountDown < 9.9f)
                    {                         
                        emission.rateOverTime = 10 * wateringCountDown;
                    }
                    if (wateringCountDown < 7 && !heal1)
                    {
                        tree.gameObject.GetComponent<Health>().Heal(1);
                        heal1 = true;
                    }
                    if (wateringCountDown < 5 && !heal2)
                    {
                        tree.gameObject.GetComponent<Health>().Heal(1);
                        heal2 = true;
                    }
                    if (wateringCountDown < 3 && !heal3)
                    {
                        tree.gameObject.GetComponent<Health>().Heal(1);
                        heal3 = true;
                    }
                    if (wateringCountDown < 1 && !heal4) 
                    {
                        tree.gameObject.GetComponent<Health>().Heal(1);
                        heal4 = true;
                    }
                    if (wateringCountDown < 0)
                    {
                        subEmitters.SetSubEmitterEmitProbability(0, 0f);                        
                    }                
                    if (wateringCountDown < -4)
                    {
                        GameValueManager.INSTANCE.addingWater = false;
                        GameValueManager.INSTANCE.carryingWater = 0;                        
                        wateringCountDown = 10;                        
                    }    
                }
            }
        }
        else
        {
            var emission = PS.emission;
            emission.rateOverTime = 0;
        }
    }
}
