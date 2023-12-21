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
        Debug.Log("Pressed");
        if (!once)
		{
			if (cullBackground.INSTANCE.Backgrounds[0].activeInHierarchy)
			{
                Debug.Log(" Switch start Activated");
                once = true;
				if (FindAnyObjectByType<Movement>().gameObject.layer == 11)
					FindAnyObjectByType<Movement>().gameObject.layer = 0;
				else if (FindAnyObjectByType<Movement>().gameObject.layer == 0)
					FindAnyObjectByType<Movement>().gameObject.layer = 11;

				if (cullBackground.INSTANCE.Backgrounds[0].activeInHierarchy)
				{            
					if (mode == 0)
					{
						Debug.Log(" Switch 0 Activated");
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
				
				StartCoroutine(Wait());
			}
            else
            {
                cullBackground.INSTANCE.CullingModeCall(0);
            }
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        once = false;
    }
	    
}
