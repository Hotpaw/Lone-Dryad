using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class activateSuck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(gameObject.name);
            if(collision.GetComponent<BatMovement>() != null)
            {

            collision.GetComponent<BatMovement>().sucker.SetTrigger("StartSucking");
            }
        }
    }
}
