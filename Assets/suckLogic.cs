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
        // FIXA SUG SKADA
    }

    public void Suck()
    {

        animator.SetTrigger("Sucking");
    }
}
