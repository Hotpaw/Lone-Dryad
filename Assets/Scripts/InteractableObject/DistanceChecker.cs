using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public SlowPlayer sp;
    
    bool triggered = false;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            if (!triggered)
            {
                PopUpText.INSTANCE.PopUpMessage("I am feeling weaker", Color.gray);
                GameValueManager.INSTANCE.IncreaseExhaustLevel();
            }
            if (triggered)
            {
                PopUpText.INSTANCE.PopUpMessage("I am feeling stronger", Color.gray);
                GameValueManager.INSTANCE.DecreaseExhaustLevel();
            }
            triggered = !triggered;
            if (GameValueManager.INSTANCE.exhaustLevel == 0)
            {
                triggered = false;
            }
            
        }
    }
}
