using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnWind : MonoBehaviour
{
    Collider2D shield;
    ParticleSystem windParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
            windParticleSystem = GetComponent<ParticleSystem>();    
        shield = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var emission = windParticleSystem.emission;
        if (GameValueManager.INSTANCE.KC)
        {
            emission.rateOverTime = 100;
            emission.rateOverDistance = 10;
            shield.enabled = true;
        }
        else
        {
            emission.rateOverTime = 0;
            shield.enabled = false;
        }
    }
}
