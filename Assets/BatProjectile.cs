using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProjectile : MonoBehaviour
{
    public Transform target;
    public float speed;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("TreeTop").transform;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            
            collision.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject,0.1f);
        }
    }
}
