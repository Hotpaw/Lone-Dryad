using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFlowers : MonoBehaviour
{
    public List <GameObject> flowers;
    public int currentHealth;
    public int healthLastFrame;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = GetComponentInParent<Health>().currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = GetComponentInParent<Health>().currentHealth;  
        if (currentHealth < healthLastFrame) 
        {
            flowers[currentHealth].gameObject.GetComponent<ParticleSystem>().startColor = Color.black;
            flowers[currentHealth].gameObject.GetComponent<ParticleSystem>().Play();          
        }

        //for (int i = 0; i <= currentHealth-1; i++)
        //{
        //    flowers[i].gameObject.GetComponent<SpriteRenderer>().color = Color.white;            
        //}        
        //for (int i = currentHealth; i < flowers.Count; i++)
        //{
        //    flowers[i].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //}
        healthLastFrame = currentHealth;
    }
}
