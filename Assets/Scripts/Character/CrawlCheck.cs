using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlCheck : MonoBehaviour
{
    public bool entered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Fix apparent delay, if the player turns around quick, they can cheese the colliders.
        if (!entered)
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                FindAnyObjectByType<Movement>().DecreaseSpeed();
                entered = true;
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                FindAnyObjectByType<Movement>().IncreaseSpeed();
                entered = false;
            }
        }
        CrawlCheck[] cChecks = FindObjectsOfType<CrawlCheck>();
        foreach (CrawlCheck cCheck in cChecks)
        {

            cCheck.entered = entered;
        }
    }
}
