using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFlowers : MonoBehaviour
{
    public List <GameObject> flowers;
    public int currentHealth;
    public int healthLastFrame;
    
    void Start()
    {
        currentHealth = GetComponentInParent<Health>().currentHealth;        
    }
        
    void Update()
    {   
        HealFlower();        
    }

    private void HealFlower()
    {
        currentHealth = GetComponentInParent<Health>().currentHealth;
        if (currentHealth < healthLastFrame)
        {
            flowers[currentHealth].gameObject.GetComponent<ParticleSystem>().startColor = Color.black;
            flowers[currentHealth].gameObject.GetComponent<ParticleSystem>().Play();
            flowers[currentHealth].gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (currentHealth > healthLastFrame)
        {
            flowers[currentHealth - 1].gameObject.GetComponent<ParticleSystem>().startColor = Color.white;
            flowers[currentHealth - 1].gameObject.GetComponent<ParticleSystem>().Play();
            for (int i = 0; i < currentHealth; i++)
            {
                flowers[i].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        healthLastFrame = currentHealth;
    }
}
