using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : InteractableObject
{
    public GameObject PlantPart;
    bool usable = true;
    public Animator animator;

    public GameObject Crystal;
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
            if (type == Type.crystal)
            {
                PlantPart.GetComponent<Animator>().Play("Grow");
                StartCoroutine(Decay());
            }
            if (type == Type.event1 && !eventUsed)
            {
                eventUsed = true;
                animator.SetTrigger("Event");
                PopUpText.INSTANCE.PopUpMessage("The Water is back", Color.white, 3f);

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
        if (Crystal != null)
            if (type == Type.crystal)
            {

                yield return new WaitForSeconds(0.8f);
                Crystal.gameObject.SetActive(true);
            }

        yield return new WaitForSeconds(3);
        PlantPart.GetComponent<Animator>().Play("Ungrow");

        usable = true;
    }

}
