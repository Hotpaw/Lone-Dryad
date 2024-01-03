
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatLogic : MonoBehaviour
{
   public float attackCooldown;
   public float timer;
   public GameObject projectile;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackCooldown)
        {
            Attack();
            timer = 0;

        }
    }
    public void Attack()
    {
        GameObject projectileClone = Instantiate(projectile, transform.position, Quaternion.identity);
        
    }
}
