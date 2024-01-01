using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{    
    public ParticleSystem particleSystem;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        Invoke("SetStormIntensity", 0.2f);
    }

    public void SetStormIntensity()
    {
        var emmision = particleSystem.emission;
        emmision.rateOverTime = GameValueManager.INSTANCE.stormStrenght * 70;
    }
}
