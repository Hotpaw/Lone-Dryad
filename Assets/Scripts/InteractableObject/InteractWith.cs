using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InteractWith : MonoBehaviour
{
    public InteractableObject interactableObject;
    public bool interactable;
    bool used = false;
    public bool unlimitedUses = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactable)
        {
            if (collision.gameObject.CompareTag("Player") && Gamepad.current.buttonEast.IsPressed() || Keyboard.current.eKey.wasPressedThisFrame == true)
            {
                if (!used)
                {
                    if (!unlimitedUses)
                    {
                        used = true;
                        interactableObject.Interact();
                        DisableInteractable();
                    }
                    else
                        interactableObject.Interact();

                }

            }
            else
            {
                return;
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                
                if (!used)
                {
                    if (!unlimitedUses)
                    {
                        used = true;
                        interactableObject.Interact();
                        DisableInteractable();
                    }
                    else
                        interactableObject.Interact();
                }
            }
            else
            {
                return;
            }
        }

    }
    public void DisableInteractable()
    {
        gameObject.SetActive(false);
    }
}
