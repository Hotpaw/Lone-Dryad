using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
    SpriteRenderer playerInteractIcon;

    private void Start()
    {
        InteractableIcon.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        playerInteractIcon = FindObjectOfType<Movement>().InteractableObject;
        playerInteractIcon.enabled = false;
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

            if (collision.gameObject.CompareTag("Player"))
            {

                if (Gamepad.current != null)
                {
                    if (Gamepad.current.buttonEast.IsActuated())
                    {

                        if (!used)
                        {
                            if (!unlimitedUses)
                            {
                                used = true;
                                interactableObject.Interact();

                            }
                            else
                                interactableObject.Interact();
                        }
                    }
                }
                else if (Keyboard.current.eKey.IsActuated())
                {

                    if (!used)
                    {
                        if (!unlimitedUses)
                        {
                            used = true;
                            interactableObject.Interact();

                        }
                        else
                            interactableObject.Interact();
                    }

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
       playerInteractIcon = FindObjectOfType<Movement>().InteractableObject;
        playerInteractIcon.DOFade(1, 0.2f).SetEase(Ease.InFlash);
        playerInteractIcon.gameObject.transform.DOPunchScale(Vector3.one, 1, 1,1).SetEase(Ease.InBounce);
        playerInteractIcon.enabled = true;
       
        if (Gamepad.current != null) playerInteractIcon.sprite = Icons[0];
        else playerInteractIcon.sprite = Icons[1];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInteractIcon.enabled = false;
    }



}
