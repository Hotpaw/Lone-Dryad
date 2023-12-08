using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerJump2 : MonoBehaviour
{

    [Header("JumpAttack")]
    [SerializeField] public float enemyJumpHeight;
    [SerializeField] Transform target;
    [SerializeField] Transform checkingGround;
    [SerializeField] Vector2 boxSize; //istället för float radius av cirkel, är det overlapbox, så då blir dte vector 2.
    [SerializeField] bool isOnGround;
    [SerializeField] public float jumpAngle;
    [SerializeField] public LayerMask groundLayer;

    Rigidbody2D body2D;


    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        isOnGround = Physics2D.OverlapBox(checkingGround.position, boxSize, jumpAngle, groundLayer); //samma som ovan, fast vecto1 och 0 är "angle".

    }

    void JumpAttack()
    {

        float distanceFromPlayer = target.position.x - transform.position.x; 

      
                            
        body2D.AddForce(new Vector2(distanceFromPlayer, enemyJumpHeight), ForceMode2D.Impulse);
       

    }
}
