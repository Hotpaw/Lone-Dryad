using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public SlowPlayer sp;
    
    bool activated = false;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!activated)
            {
                // Add GameManager reference to increase some kind of exhaust level. and if it becomes greater then X.
                // move the player back to the tree and reset exhaust level.
                sp.DistanceFeedBack();
                activated = true;
                GameValueManager.INSTANCE.IncreaseExhaustLevel();
            }
        }

    }
}
