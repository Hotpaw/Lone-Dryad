using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InteractWith : MonoBehaviour
{
    public InteractableObject interactableObject;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Gamepad.current.buttonEast.IsPressed())
        {
            interactableObject.Interact();
        }
        else
        {
            return;
        }
    }
}
