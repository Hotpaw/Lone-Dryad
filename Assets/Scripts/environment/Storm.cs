using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{
    public float stormStrenght;
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    public void IncreaseStormIntensity()
    {
        stormStrenght++;
        var emmision = particleSystem.emission;
        emmision.rateOverTime = stormStrenght * 20;
    }
}
