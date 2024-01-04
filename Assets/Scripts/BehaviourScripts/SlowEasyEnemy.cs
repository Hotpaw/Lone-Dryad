using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SlowEasyEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform attackPoint;
    public Transform theLeftSpawnPoint;
    public Transform DiePoint;
    public float moveSpeed;
    public float attackSpeed;
    public float gravity;
    public int patrolDestination;
    public bool attacking;
    bool once;
    public bool movingRight;
    Rigidbody2D rigidbody2D;
    public bool isBall;

    public Animator animator;

    [Header("Crawl Audio")]
    public GameObject crawlSound;
 

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); 
        
    }
    private void Update()
    {
        animator.SetBool("Ball", isBall);
        if (GetComponent<Health>().currentHealth <= 0 && !once)
        {
            once = true;
            isBall = true;
            gravity = -3;
            StartCoroutine(DelayGravity());
            crawlSound.SetActive(false); //stänga av crawl ljud

        }
        if (movingRight)
        {
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (!attacking)
        {
            crawlSound.SetActive(true); //sätta på kräl när den börjar röra sig
            
            rigidbody2D.gravityScale = gravity;
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < 1.5f)
                {
                    movingRight = false;
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < 1.5f)
                {
                    animator.SetTrigger("Jump");
                    StartCoroutine(DelayAttack());
                    patrolDestination = 2;
                }
            }
            if (patrolDestination == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[2].position) < 1.5f)
                {
                    movingRight = true;
                    patrolDestination = 3;
                }
            }

            if (patrolDestination == 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[3].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[3].position) < 1.5f)
                {
                    animator.SetTrigger("Jump");
                    StartCoroutine(DelayAttack());
                    patrolDestination = 0;
                    crawlSound.SetActive(false); //stänga av kräl när den hoppar
                }
            }
        }
        else
        {
            rigidbody2D.gravityScale = 0;
            transform.position = Vector2.MoveTowards(transform.position, attackPoint.position, attackSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, attackPoint.position) < 0.7f)
            {
                isBall = true;
                FindAnyObjectByType<TreeScript>().GetComponent<Health>().TakeDamage(1);
                attacking = false;                
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isBall = false;
        }
        if (collision.gameObject.layer == 12)
        {
            this.GetComponent<Health>().TakeDamage(1);
        }
    }
    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(0.5f);
        attacking = true;
    }
    public IEnumerator DelayGravity()
    {
        yield return new WaitForSeconds(0.2f);
        gravity = 5;
    }
    
}