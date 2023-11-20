using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemy;
    Transform target;
    Rigidbody2D rb2D;
    float enemySpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("EnemyFollow", 0.5f);

        EnemyFollow();

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetDirection = target.position - transform.position;

        targetDirection.Normalize();

        rb2D.velocity = targetDirection * enemySpeed;

    }

    public void EnemyFollow()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
}

