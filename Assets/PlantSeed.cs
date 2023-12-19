using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : InteractableObject
{
    public GameObject PlantPart;
    bool usable = true;

    void Start()
    {

    }
    void Update()
    {

    }
    public override void Interact()
    {
        if (usable)
        {
           

           
            PlantPart.GetComponent<Animator>().Play("Grow");
            StartCoroutine(Decay());
        }
    }
    IEnumerator Decay()
    {
        usable = false;
       
        yield return new WaitForSeconds(3);
        PlantPart.GetComponent<Animator>().Play("Ungrow");
        usable = true;
    }

}
