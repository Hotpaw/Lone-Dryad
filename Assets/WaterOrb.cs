using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class WaterOrb : MonoBehaviour
{
    GameObject tree;
    Vector3 followDryadPosition;

    ParticleSystem PS;
    public float wateringCountDown = 10;

    public Vector3 WateringTreePosition;
    public float WateringYOffset;


    // Start is called before the first frame update
    void Start()
    {
        tree = FindAnyObjectByType<Tree>().gameObject;
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
