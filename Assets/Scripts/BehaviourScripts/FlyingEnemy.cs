using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject treeTop;
    public GameObject enemyPause;
    Rigidbody2D flyingEnemy2D;

    public bool isPausing;

    public float flyingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
        flyingEnemy2D = GetComponent<Rigidbody2D>();
       
        enemyPause = GameObject.FindGameObjectWithTag("Pause");

        treeTop = GameObject.FindGameObjectWithTag("TreeTop");

        SpawnInAir();
        isPausing = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        Pause();
       

    }


    public void Pause()
    {
        if (isPausing)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyPause.transform.position, flyingSpeed * Time.deltaTime);

        }


        if (Vector2.Distance(transform.position, enemyPause.transform.position) < 0.1f) //0.1f  är en threshold value som ska kolla om distansen mellan två punkter är mindre än 0.1f. 
        {
            isPausing = false;
            Invoke("NextPoint", 2);


        }

    }

    public void NextPoint()
    {

        transform.position = Vector2.MoveTowards(transform.position, treeTop.transform.position, flyingSpeed * Time.deltaTime);

    }

    public void SpawnInAir()
    {

        Vector3 airSpawn = new Vector3(transform.position.x, transform.position.y, 4f); //4 är position av z. innebär att objectet spawnar över marken. 
        transform.position = airSpawn;

    }


}
