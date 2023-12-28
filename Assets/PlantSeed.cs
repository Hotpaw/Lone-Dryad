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
    public GameObject[] waterfalls;
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
                waterfalls[0].SetActive(true);
               // StartCoroutine(CheckWaterfallLength());
                PopUpText.INSTANCE.PopUpMessage("The Water is returning", Color.white, 3f);
            }

            if (usable)
            {
                PlantPart.GetComponent<Animator>().Play("Grow");
                StartCoroutine(Decay());
            }
        }

    }
    private IEnumerator CheckWaterfallLength()
    {
        // Null check for waterfalls[0]
        if (waterfalls[0] == null)
        {
            Debug.LogError("waterfalls[0] is not assigned.");
            yield break; // Exit the coroutine if waterfalls[0] is null
        }

        bool anyWaterfallReachedFullLength = false;

        // Wait until any of the child waterfalls reach their full length
        while (!anyWaterfallReachedFullLength)
        {
            foreach (Transform child in waterfalls[0].transform)
            {
                WaterController waterController = child.GetComponent<WaterController>();
                if (waterController != null && waterController.HasReachedFullLength())
                {
                    anyWaterfallReachedFullLength = true;
                    break;
                }
            }

            yield return null; // Wait for the next frame before checking again
        }

        // Activate waterfalls[1] if it's assigned
        if (waterfalls[1] != null)
        {
            waterfalls[1].SetActive(true);
        }
        else
        {
            Debug.LogError("waterfalls[1] is not assigned.");
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
