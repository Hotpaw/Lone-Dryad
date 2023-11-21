using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class EnemyInteractWith : MonoBehaviour
{
    public InteractableObject interactableObject;
    public bool interactable;
    bool used = false;    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactable)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (!used)
                {                    
                        used = true;
                        
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

