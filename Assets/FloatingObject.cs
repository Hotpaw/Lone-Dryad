using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class FloatingObject : MonoBehaviour
{
    public GameObject floatingTo;
    //Added random xOffset for diffrent landing position.
    public float xOffset;
    public GameObject landingPosition;
    bool destroyThisSeed;
    public float destroyTimer;

    Rigidbody2D floating2D;

    public float floatStrength;

    float objectRotationStrength = 1f;

    public GameObject corruptPlant;



    // Start is called before the first frame update
    void Start()
    {
        xOffset = Random.Range(GameValueManager.INSTANCE.treeLevel * 15, GameValueManager.INSTANCE.treeLevel * -15);
        floating2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (floatingTo != null)
        {
            if (destroyThisSeed)
            {
                destroyTimer += Time.deltaTime;
                if (destroyTimer > 0.2)
                    Destroy(gameObject);
            }


            Vector2 directionTarget = (new Vector3(floatingTo.transform.position.x + xOffset, floatingTo.transform.position.y) - transform.position).normalized;
            Vector2 floatForce = directionTarget * floatStrength;

            float objectRotation = objectRotationStrength * Mathf.Sin(Time.time);

            //floating2D.AddTorque(objectRotation);

            floating2D.AddForce(directionTarget * floatStrength);

            print(Vector2.Distance(floatingTo.transform.position, transform.position));

            if (Vector2.Distance(floatingTo.transform.position, transform.position) < 1)
            {
                floating2D.velocity = Vector2.zero;
            }
        }
        else
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!destroyThisSeed && GameValueManager.INSTANCE.treeIsALive)
        {
            GameObject plant = Instantiate(corruptPlant, landingPosition.transform.position, Quaternion.identity);
            plant.transform.SetParent(null);
            destroyThisSeed = true;
        }
        else
            Destroy(gameObject);
        
    }
}
