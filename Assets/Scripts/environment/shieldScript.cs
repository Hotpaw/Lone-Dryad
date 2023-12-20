using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class shieldScript : MonoBehaviour
{
    public Collider2D shieldCollider;
    
    
    void Update()
    {
        if (GameValueManager.INSTANCE.theShieldIsActive)
        {
            shieldCollider.enabled = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Storm"))
        {
            Collider2D collider1 = collision.gameObject.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider1, shieldCollider, true);
        }
    }
}
