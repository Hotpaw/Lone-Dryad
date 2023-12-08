using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerAttack : MonoBehaviour
{
    public bool coolDown = false;
    public float attackSpeed;
    public GameObject[] Projectiles;
    public Transform attackPoint;
    private void Update()
    {
     
    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (!coolDown && context.action.IsPressed() && GameValueManager.INSTANCE.thePowerToThrowNuts)
        {
            Debug.Log("PRESSED ATTACK");
            StartCoroutine(AttackCooldown());
        }
    }
    IEnumerator AttackCooldown()
    {
        FindAnyObjectByType<Movement>().GetComponent<Animator>().SetTrigger("Throw");
        coolDown = true;
        yield return new WaitForSeconds(0.3f);
      
        FireProjectile();
        yield return new WaitForSeconds(attackSpeed);
        coolDown = false;
    }
    public void FireProjectile()
    {
       GameObject projectileClone = Instantiate(Projectiles[0], attackPoint.transform.position, Quaternion.identity);
    }
}
