using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : InteractableObject
{
    public GameObject PlantPart;
    bool usable = true;
    public Animator animator;

    public enum Type { event1, grow, crystal };
    public Type type;

    bool eventUsed = false;
    void Start()
    {

    }
    void Update()
    {

    }
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.thePowerToPlant)
        {

            if (type == Type.event1 && !eventUsed)
            {
                eventUsed = true;
                animator.SetTrigger("Event");

            }
            if (usable)
            {
                PlantPart.GetComponent<Animator>().Play("Grow");
                StartCoroutine(Decay());
            }
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
