using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using TMPro;
public class InteractWith : MonoBehaviour
{
    public enum Type { Tree, plant, normal, crystal , cave}
    public Type type;
    public InteractableObject interactableObject;
    public string interactableDescription;
    public GameObject InteractableIcon;
    public Sprite[] Icons;
    public bool interactable;
    public Vector2 iconOffset;
    bool used = false;
    public bool unlimitedUses = false;
    SpriteRenderer playerInteractIcon;
    bool activated = false;


    public ParticleSystem particleSystemPrefab; // Reference to the particle system prefab
    private ParticleSystem instantiatedParticleSystem; // To
    private void Start()
    {

        if (interactableObject != null)
        {
            InteractableIcon.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (FindObjectOfType<Movement>() != null)
        {
            playerInteractIcon = FindObjectOfType<Movement>().InteractableObject;
            playerInteractIcon.enabled = false;
        }
    }
    private void Update()
    {

        HandleParticleSystem();

    }
    private void HandleParticleSystem()
    { // Check if the particle system prefab is assigned
        if (particleSystemPrefab == null)
        {
            return; // Exit the method if the prefab is not assigned
        }
        bool shouldHaveParticleSystem = false;
        if(type == Type.cave)
        {
            shouldHaveParticleSystem = false;
            return;
        }
        // Check conditions for each type and set shouldHaveParticleSystem accordingly
        if ((type == Type.crystal && GameValueManager.INSTANCE.thePowerToPickUpCrystals) ||
            (type == Type.Tree && (GameValueManager.INSTANCE.gotWater || GameValueManager.INSTANCE.nextLevelAvailable)) ||
            (type == Type.plant && GameValueManager.INSTANCE.thePowerToPlant) ||
            (type == Type.normal || type == Type.cave))
        {
            shouldHaveParticleSystem = true;
        }

        // Instantiate the particle system if needed
        if (shouldHaveParticleSystem && instantiatedParticleSystem == null)
        {
            instantiatedParticleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity, transform);
        }

        // Enable or disable the particle system based on the condition
        if (instantiatedParticleSystem != null)
        {
            instantiatedParticleSystem.gameObject.SetActive(shouldHaveParticleSystem);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(type == Type.crystal && GameValueManager.INSTANCE.thePowerToPickUpCrystals)
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
        if (type == Type.Tree && GameValueManager.INSTANCE.gotWater || type == Type.Tree && GameValueManager.INSTANCE.nextLevelAvailable)
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
        if (type == Type.plant && GameValueManager.INSTANCE.thePowerToPlant)
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
        if (type == Type.normal || type == Type.cave)
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


    }

    private void DisplayInteractableIcon()
    {
        if (!activated)
        {
            playerInteractIcon.gameObject.SetActive(true);
            if (interactableDescription != null && playerInteractIcon.GetComponentInChildren<TextMeshProUGUI>() != null)
            {
                playerInteractIcon.GetComponentInChildren<TextMeshProUGUI>().text = interactableDescription;
            }

            if (playerInteractIcon.transform.localScale.x >= 2)
            {
                playerInteractIcon.transform.localScale = Vector3.one;
            }

            activated = true;
            playerInteractIcon = FindObjectOfType<Movement>().InteractableObject;
            playerInteractIcon.DOFade(1, 0.2f).SetEase(Ease.InFlash);
            if (playerInteractIcon.transform.localScale == new Vector3(2, 2, 2))
                playerInteractIcon.gameObject.transform.DOPunchScale(Vector3.one, 1, 1, 1).SetEase(Ease.InBounce);

            playerInteractIcon.enabled = true;


            if (Gamepad.current != null) playerInteractIcon.sprite = Icons[0];
            else playerInteractIcon.sprite = Icons[1];
        }




    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        activated = false;
        playerInteractIcon.gameObject.transform.localScale = Vector3.one;
        playerInteractIcon.enabled = false;
        playerInteractIcon.gameObject.SetActive(false);
    }



}
