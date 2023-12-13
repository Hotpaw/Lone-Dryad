using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    public float minIntensity = 1.0f;
    public float maxIntensity = 5f;
    public float pulseSpeed = 1.0f;

    public Light pulsatingLight; //som rigidbody2d
    // Start is called before the first frame update
    void Start()
    {
        
        pulsatingLight = GetComponent<Light>(); //hämta component light

    }

    // Update is called once per frame
    void Update()
    {
        
        float pulsating = Mathf.PingPong(Time.time * pulseSpeed, maxIntensity -  minIntensity) + minIntensity; //beräkna pulserandet 

        pulsatingLight.intensity = pulsating; //applicera intensiteten till ljuset. ".intensity" är en del av unity Light. 




    }
}
