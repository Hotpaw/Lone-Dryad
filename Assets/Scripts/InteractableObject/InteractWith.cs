using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using TMPro;

public class InteractWith : MonoBehaviour
{
    public enum Type { Tree, Plant, Normal, Crystal, Cave }
    public Type type;
    public InteractableObject interactableObject;
    public string interactableDescription;
    public GameObject InteractableIcon;
    public Sprite[] Icons;
    public bool interactable;
    public Vector2 iconOffset;
    private bool used = false;
    public bool unlimitedUses = false;
    private SpriteRenderer playerInteractIcon;
    private bool activated = false;
    private bool playerIsWithinRange = false;
    public ParticleSystem particleSystemPrefab; // Reference to the particle system prefab
    private ParticleSystem instantiatedParticleSystem; // Instance of the particle system
    public bool noParticles;
    LayerMask groundLayer;

    private void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
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
        if (!noParticles)
        {
            HandleParticleSystem();
        }
        CheckForInteraction();
    }

    private void HandleParticleSystem()
    {
        if (particleSystemPrefab == null)
        {
            return; // Exit the method if the prefab is not assigned
        }

        bool shouldHaveParticleSystem = false;
        // ... [Your existing conditions for shouldHaveParticleSystem]

        // Evaluate conditions to determine if the particle system should be present
        shouldHaveParticleSystem = DetermineIfParticleSystemShouldBePresent();

        // Instantiate or adjust the particle system if needed
        if (shouldHaveParticleSystem)
        {
            if (instantiatedParticleSystem == null)
            {
                // Instantiate at the ground position
                instantiatedParticleSystem = Instantiate(particleSystemPrefab, CalculateGroundPosition(), Quaternion.identity);
                instantiatedParticleSystem.transform.SetParent(transform, false);
            }
            else
            {
                // Update position to the ground position
                instantiatedParticleSystem.transform.position = CalculateGroundPosition();
            }
        }
        else
        {
            // If particle system exists but should not, destroy it
            if (instantiatedParticleSystem != null)
            {
                Destroy(instantiatedParticleSystem.gameObject);
                instantiatedParticleSystem = null;
            }
        }
    }

    // Method to calculate the closest ground position downwards
    private Vector2 CalculateGroundPosition()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, groundLayer);
        return hit.collider != null ? hit.point : transform.position;
    }

    // Method to determine if the particle system should be present
    private bool DetermineIfParticleSystemShouldBePresent()
    {

        switch (type)
        {
            case Type.Plant:
                return GameValueManager.INSTANCE.thePowerToPlant;
            case Type.Crystal:
                return GameValueManager.INSTANCE.thePowerToPickUpCrystals;
            case Type.Tree: 
                return true;
            case Type.Normal:
                return true;
            default:
                return false;
        }
    }

    private void CheckForInteraction()
    {
        if (!interactable || !playerIsWithinRange) return;

        Movement player = FindObjectOfType<Movement>();
        if (player == null || player.pickedUp || player.isCrawling) return;

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            player.PickupAnimation();
        }
        else if (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            player.PickupAnimation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsWithinRange = true;
          
        }
        if (type == Type.Crystal && GameValueManager.INSTANCE.thePowerToPickUpCrystals)
        {
            InteractLogic(collision);
        }
        if (type == Type.Tree && GameValueManager.INSTANCE.gotWater || type == Type.Tree && GameValueManager.INSTANCE.nextLevelAvailable)
        {
            InteractLogic(collision);
        }
        if (type == Type.Plant && GameValueManager.INSTANCE.thePowerToPlant)
        {
            InteractLogic(collision);
        }
        if (type == Type.Normal || type == Type.Cave)
        {
            InteractLogic(collision, true);
        }
    }

    public void InteractLogic(Collider2D collision, bool cantPickup = false)
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
                        PerformInteraction();
                    }
                }
                else if (Keyboard.current.eKey.IsActuated())
                {
                    PerformInteraction();
                }
            }
            else
            {
                return;
            }
        }
    }

    private void PerformInteraction()
    {
        if (!used)
        {
            if (!unlimitedUses)
            {
                used = true;
                interactableObject.Interact();
            }
            else
            {
                interactableObject.Interact();
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

            // Reset scale to original before applying new animation
            playerInteractIcon.transform.localScale = Vector3.one;

            activated = true;
            playerInteractIcon.DOFade(1, 0.2f).SetEase(Ease.InFlash);

            // Apply scale animation
            playerInteractIcon.gameObject.transform.DOScale(Vector3.one * 1.1f, 1).SetEase(Ease.InBounce).OnComplete(() =>
            {
                playerInteractIcon.transform.localScale = Vector3.one;
            });

            playerInteractIcon.enabled = true;
            playerInteractIcon.sprite = Gamepad.current != null ? Icons[0] : Icons[1];
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activated = false; 
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsWithinRange = false;
           
        }
        playerInteractIcon.gameObject.transform.localScale = Vector3.one;
        playerInteractIcon.enabled = false;
        playerInteractIcon.gameObject.SetActive(false);
    }
}