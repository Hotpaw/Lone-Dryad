using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PickUpObject : MonoBehaviour
{

    public Transform holdSpot;
    public LayerMask pickUpMask;

    public Vector3 Direction {  get; set; }

    private GameObject objectholding;
    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.B)) 
        {
        
          if (objectholding) //kolla om du h�ller n�got
          {

            //logic f�r att sl�ppa/kasta objektet



          }
          else
          {

                //logic f�r att plocka upp objektet
               Collider2D pickUpObject =  Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                
                if (pickUpObject != null) 
                {

                    objectholding  = pickUpObject.gameObject; //om det finns ett object att h�mta upp s� ska den sparas i pickUpObject
                    objectholding.transform.position = holdSpot.position; //byra positionen f�r det sparade objektet till positionen d�r den ska "b�ras"
                    objectholding.transform.parent = transform; //g�r s� att objektet f�rlyttas med spelaren, om objektet �r ett child till spelaren. 

                    if (objectholding.GetComponent<Rigidbody2D>()) //kolla om objektet vi plockat har en rigidbody 2d
                    {

                        objectholding.GetComponent<Rigidbody2D>().simulated = false; //har den en rigidbody m�ste simulated s�ttas till false, annars f�ljer inte objektet efter spelaren. 

                    }

                }

          }

          

         
        
        }
    }
}
