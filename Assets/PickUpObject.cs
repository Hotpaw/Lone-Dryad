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
        
          if (objectholding) //kolla om du håller något
          {

            //logic för att släppa/kasta objektet



          }
          else
          {

                //logic för att plocka upp objektet
               Collider2D pickUpObject =  Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                
                if (pickUpObject != null) 
                {

                    objectholding  = pickUpObject.gameObject; //om det finns ett object att hämta upp så ska den sparas i pickUpObject
                    objectholding.transform.position = holdSpot.position; //byra positionen för det sparade objektet till positionen där den ska "bäras"
                    objectholding.transform.parent = transform; //gör så att objektet förlyttas med spelaren, om objektet är ett child till spelaren. 

                    if (objectholding.GetComponent<Rigidbody2D>()) //kolla om objektet vi plockat har en rigidbody 2d
                    {

                        objectholding.GetComponent<Rigidbody2D>().simulated = false; //har den en rigidbody måste simulated sättas till false, annars följer inte objektet efter spelaren. 

                    }

                }

          }

          

         
        
        }
    }
}
