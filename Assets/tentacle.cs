using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle : MonoBehaviour
{
  
    Rigidbody2D rb;
    Transform target;
    public float radius;
    LineRenderer lineRenderer;
    public GameObject previous;
    // Start is called before the first frame update
    bool reach = false;
    void Start()
    {
        target = FindAnyObjectByType<Movement>().transform;
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, previous.transform.position);
        if (Vector2.Distance(transform.position, target.position) < radius)
        {
            rb.AddForce(target.position - transform.position, ForceMode2D.Force);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            reach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        reach = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
