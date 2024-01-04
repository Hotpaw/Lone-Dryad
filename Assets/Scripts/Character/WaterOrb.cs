using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class WaterOrb : MonoBehaviour
{
    public TreeScript tree;
    public float playerfollowraidus;
    public Vector3 followPosition;

    
    public float wateringCountDown = 10;
    SpriteRenderer SpriteRenderer;
    public float scaleScaler;


    public Transform wateringTreePosition;
    public float WateringYOffset;
    public bool once;

    //Healing bools
    bool heal1;
    bool heal2;
    bool heal3;
    bool heal4;

    // Start is called before the first frame update
    void Start()
    {        
        
        SpriteRenderer = GetComponent<SpriteRenderer>();
        
        SpriteRenderer.enabled = false;
    }

    
    void Update()
    {
        if (!GameValueManager.INSTANCE.addingWater)
        {
            if (Vector2.Distance(transform.position, FindAnyObjectByType<Movement>().gameObject.transform.position) > playerfollowraidus)
            {
                followPosition.x = FindAnyObjectByType<Movement>().gameObject.transform.position.x - 2;
                followPosition.y = FindAnyObjectByType<Movement>().gameObject.transform.position.y + 1;
                transform.position = Vector2.MoveTowards(transform.position, followPosition, 7 * Time.deltaTime);
            }
            heal1 = false;
            heal2 = false;
            heal3 = false; 
            heal4 = false;
        }
        if (GameValueManager.INSTANCE.gotWater)
        {
            if (transform.localScale.x < 1 && !GameValueManager.INSTANCE.addingWater) 
            {
                scaleScaler += 0.5f * Time.deltaTime;
                transform.localScale = new Vector2(scaleScaler, scaleScaler); 
            }
            if (!once)
            {
                transform.position = new Vector3(-25,-16);
                once = true;
            }
            SpriteRenderer.enabled = true;
                     
            if (GameValueManager.INSTANCE.addingWater)
            {
                transform.position = Vector3.MoveTowards(transform.position, wateringTreePosition.position, 0.1f);
                if (transform.position == wateringTreePosition.position)
                {
                    if (transform.localScale.x > 0)
                    {
                        scaleScaler -= 0.4f * Time.deltaTime;
                        transform.localScale = new Vector2(scaleScaler, scaleScaler);
                        this.GetComponent<Animator>().SetBool("Watering", true);
                    }                    
                    wateringCountDown -= (2 *Time.deltaTime);                   
                                        
                    if (wateringCountDown < 7 && !heal1)
                    {
                        
                        tree.gameObject.GetComponent<Health>().Heal(1);
                        heal1 = true;
                    }
                    if (wateringCountDown < 5 && !heal2)
                    {
                        tree.gameObject.GetComponent<Health>().Heal(1);
                        heal2 = true;
                    }
                    if (wateringCountDown < 3 && !heal3)
                    {
                        tree.gameObject.GetComponent<Health>().Heal(1);
                        heal3 = true;
                    }
                    if (wateringCountDown < 1 && !heal4) 
                    {
                        tree.gameObject.GetComponent<Health>().Heal(1);
                        heal4 = true;
                    }
                    if (wateringCountDown < 0)
                    {
                        SpriteRenderer.enabled = false;
                        this.GetComponent<Animator>().SetBool("Watering", false);
                    }                
                    if (wateringCountDown < -4)
                    {
                        GameValueManager.INSTANCE.addingWater = false;                                               
                        wateringCountDown = 10;
                        GameValueManager.INSTANCE.gotWater = false;
                        once = false;
                    }    
                }
            }
        }        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, playerfollowraidus);
    }
}
