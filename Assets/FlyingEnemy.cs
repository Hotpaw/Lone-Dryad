using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject treeTop;

    Rigidbody2D flyingEnemy2D;

    public float flyingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
        flyingEnemy2D = GetComponent<Rigidbody2D>();
        treeTop = GameObject.FindGameObjectWithTag("TreeTop");

    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    public void Chase()
    {

        transform.position = Vector2.MoveTowards(transform.position, treeTop.transform.position, flyingSpeed * Time.deltaTime);
        transform.rotation = Quaternion.identity;
    }
}
