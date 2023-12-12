using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suckLogic : MonoBehaviour
{
    Animator animator;
    public bool sucking = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
       if(sucking)
        {
            StartCoroutine(StealingHealth());
        }
    }

    public void Suck()
    {

        animator.SetTrigger("Sucking");
        sucking = true;
    }

    IEnumerator StealingHealth()
    {
        sucking = false;
        if(FindObjectOfType<TreeScript>() != null)
        {

        FindObjectOfType<TreeScript>().gameObject.GetComponent<Health>().TakeDamage(1);
        }
        yield return new WaitForSeconds(3f);
        sucking = true;
    }
}
