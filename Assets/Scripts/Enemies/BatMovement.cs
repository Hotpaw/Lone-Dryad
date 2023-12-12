using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public Transform waitAfterSpawn;
    public Transform target;
    public Animator sucker;

    public bool isPausing;

    public float flyingSpeed;

   
    // Start is called before the first frame update
    void Start()
    {
        
    
        isPausing = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        Pause();
     
        if (gameObject.transform.position.x < FindAnyObjectByType<Tree>().gameObject.transform.position.x)
        {
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
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

 


}
