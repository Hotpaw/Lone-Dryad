using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public Transform waitAfterSpawn;
    public Transform target;
   

    public bool isPausing;

    public float flyingSpeed;

    bool suckInitiated = false;
    // Start is called before the first frame update
    void Start()
    {
        
      
        SpawnInAir();
        isPausing = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        Pause();
       if(!suckInitiated && transform.position == target.position)
        {
            GetComponentInChildren<Animator>().SetTrigger("StartSucking");
            suckInitiated = true;
            /// FIX COD IN THE SUCKER TO SUCKITY SUCKY SUCK SUCK
        }

    }

   
    public void Pause()
    {
        if (isPausing)
        {
            transform.position = Vector2.MoveTowards(transform.position, waitAfterSpawn.transform.position, flyingSpeed * Time.deltaTime);

        }


        if (Vector2.Distance(transform.position, waitAfterSpawn.transform.position) < 0.1f) //0.1f  är en threshold value som ska kolla om distansen mellan två punkter är mindre än 0.1f. 
        {
            isPausing = false;
            Invoke("NextPoint", 2);


        }

    }

    public void NextPoint()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, flyingSpeed * Time.deltaTime);

    }

    public void SpawnInAir()
    {

        Vector3 airSpawn = new Vector3(transform.position.x, transform.position.y, 4f); //4 är position av z. innebär att objectet spawnar över marken. 
        transform.position = airSpawn;

    }


}
