using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
   

    float timer;
    float cooldown = 1f;
    public int damage;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            gameObject.SetActive(false);
        }
           
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            gameObject.SetActive(false);

        }

    }
}
