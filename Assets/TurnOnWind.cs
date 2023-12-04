using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnWind : MonoBehaviour
{
    ParticleSystem windParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
            windParticleSystem = GetComponent<ParticleSystem>();        
    }

    // Update is called once per frame
    void Update()
    {
        var emission = windParticleSystem.emission;
        if (GameValueManager.INSTANCE.KC)
        {
            emission.rateOverTime = 200;
        }
        else
            emission.rateOverTime = 0;
    }
}
