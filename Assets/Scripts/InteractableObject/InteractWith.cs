using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InteractWith : MonoBehaviour
{
    public InteractableObject interactableObject;
    public GameObject InteractableIcon;
    public Sprite[] Icons;
    public bool interactable;
    public Vector2 iconOffset;
    bool used = false;
    public bool unlimitedUses = false;

    private void Start()
    {
        InteractableIcon.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void Update()
    {
       // Update the icon to change during runtime whenever a controll is disconnected
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DisplayInteractableIcon();

      
        if (interactable)
        {

            if (collision != null && collision.gameObject.CompareTag("Player") && Gamepad.current.buttonEast.IsPressed() || Keyboard.current.eKey.wasPressedThisFrame == true)
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

    private void DisplayInteractableIcon()
    {
        InteractableIcon.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        InteractableIcon.transform.localPosition = iconOffset;
        if (Gamepad.current != null) InteractableIcon.gameObject.GetComponent<SpriteRenderer>().sprite = Icons[0];
        else InteractableIcon.gameObject.GetComponent<SpriteRenderer>().sprite = Icons[1];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractableIcon.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void DisableInteractable()
    {
        gameObject.SetActive(false);
    }


}
