using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackValue : MonoBehaviour
{
    public int damage;

    //public int currentHealth;
    //public int maxHealth;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    currentHealth = maxHealth;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void Damage(int damageAmount)
    //{
    //    damageAmount -= currentHealth;

    //    if (damageAmount <= 0 )
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.CompareTag("Tree"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
