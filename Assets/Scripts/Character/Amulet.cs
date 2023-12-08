using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amulet : MonoBehaviour
{
    ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameValueManager.INSTANCE.KC)
        {
            PS.Play();
        }
    }
}
