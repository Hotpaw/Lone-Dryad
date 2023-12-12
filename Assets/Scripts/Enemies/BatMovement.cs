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
        
     // fix null referens on game over
        if (FindAnyObjectByType<Tree>().gameObject != null && gameObject.transform.position.x < FindAnyObjectByType<Tree>().gameObject.transform.position.x)
        {
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        MoveTowards();
    }

   
    public void Pause()
    {
       
    }

    public void MoveTowards()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, flyingSpeed * Time.deltaTime);

    }

 


}
