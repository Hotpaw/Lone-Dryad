using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CaveSwitch : InteractableObject
{    
    public int mode = 0;
    public bool once;
    public override void Interact()
    {

        if (!once){

			if (cullBackground.INSTANCE.Backgrounds[0].activeInHierarchy)

			{
				once = true;
				if (FindAnyObjectByType<Movement>().gameObject.layer == 11)
					FindAnyObjectByType<Movement>().gameObject.layer = 0;
				else if (FindAnyObjectByType<Movement>().gameObject.layer == 0)
					FindAnyObjectByType<Movement>().gameObject.layer = 11;

				if (cullBackground.INSTANCE.Backgrounds[0].activeInHierarchy)
				{            
					if (mode == 0)
					{                
						cullBackground.INSTANCE.CullingModeCall(1);                
					}
					if(mode == 1)
					{
						cullBackground.INSTANCE.CullingModeCall(2);
					}
					if(mode == 2)
					{
						cullBackground.INSTANCE.CullingModeCall(3);
					}
				}
				else
				{            
					cullBackground.INSTANCE.CullingModeCall(0);           
				}
				StartCoroutine(Wait());
			}
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        once = false;
    }

    
}
