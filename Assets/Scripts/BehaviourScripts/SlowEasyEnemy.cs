using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SlowEasyEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform attackPoint;
    public float moveSpeed;
    public float attackSpeed;
    public float gravity;
    public int patrolDestination;
    public bool attacking; 
    Rigidbody2D rigidbody2D;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!attacking)
        {
            rigidbody2D.gravityScale = gravity;
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < 1.5f)
                {                    
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < 1.5f)
                {
                    attacking = true;
                    patrolDestination = 2;
                }
            }
            if (patrolDestination == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[2].position) < 1.5f)
                {                    
                    patrolDestination = 3;
                }
            }

            if (patrolDestination == 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[3].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[3].position) < 1.5f)
                {
                    attacking = true;
                    patrolDestination = 0;
                }
            }
        }
        else
        {
            rigidbody2D.gravityScale = 0;
            transform.position = Vector2.MoveTowards(transform.position, attackPoint.position, attackSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, attackPoint.position) < 0.7f)
            {
                
                FindAnyObjectByType<TreeScript>().GetComponent<Health>().TakeDamage(1);
                attacking = false;                
            }
        }
    }
}