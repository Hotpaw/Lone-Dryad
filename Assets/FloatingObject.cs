using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatingObject : MonoBehaviour
{
    public GameObject floatingTo;

    Rigidbody2D floating2D;

    public float floatStrength;

    float objectRotationStrength = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
        floating2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      Vector2 directionTarget = (floatingTo.transform.position - transform.position).normalized;
      Vector2 floatForce = directionTarget * floatStrength;

        float objectRotation = objectRotationStrength * Mathf.Sin(Time.time);

        floating2D.AddTorque(objectRotation);

        floating2D.AddForce(directionTarget * floatStrength);

        print(Vector2.Distance(floatingTo.transform.position, transform.position));

        if (Vector2.Distance(floatingTo.transform.position, transform.position) < 1)
        {
            floating2D.velocity = Vector2.zero;
        }
        

    }


}
