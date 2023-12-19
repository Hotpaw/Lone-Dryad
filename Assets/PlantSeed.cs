using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : InteractableObject
{
    public GameObject PlantPart;
    public GameObject FlowerPart;
    public float Height;
    public float speed;

    bool growing = false;
    void Start()
    {

    }
    void Update()
    {
        if (growing)
        {
            if (PlantPart.transform.position.y < Height)
            {
                PlantPart.transform.position += new Vector3(0, 1) * speed *Time.deltaTime;
            }

        }
    }
    public override void Interact()
    {
        StartCoroutine(growPlant());
    }
    IEnumerator growPlant()
    {
        growing = true;
        yield return null;
    }
}
