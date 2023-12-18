using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CentipedeWeakPoint : MonoBehaviour
{
    public ParticleSystem ps;
    private void OnTriggerEnter2D(Collider2D collision)
    {           
        if (collision.gameObject.CompareTag("PlayerFeet"))
        {
            if (collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity.y < 0)
            {
                ps.Play();
                GetComponentInParent<JumpedOn>().JumpedOnScale();
                GetComponentInParent<SlowEasyEnemy>().moveSpeed = 0;
                GetComponentInParent<SlowEasyEnemy>().attackSpeed = 0;
                StartCoroutine(DelayDamage());
            }
        }
    }
    public IEnumerator DelayDamage()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponentInParent<Health>().TakeDamage(1);
    }
}

