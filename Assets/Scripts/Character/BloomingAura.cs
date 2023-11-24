using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomingAura : MonoBehaviour
{
    public GameObject flower;
    public Movement movement;
    public float flowerTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        flowerTimer += Time.deltaTime;
        if (flowerTimer > 5f && movement.isGrounded ) 
        {
            Instantiate(flower, new Vector3 (transform.position.x, transform.position.y - 0.475f, 0), transform.rotation);
            flowerTimer = 0;
        }
    }
}