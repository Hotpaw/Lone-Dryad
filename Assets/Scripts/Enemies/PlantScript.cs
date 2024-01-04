using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlantScript : MonoBehaviour
{
    public float growTimer;
    public SpriteRenderer spriteRenderer;
    public bool growing = true;

    public float growSize = 1;
    public float growSpeed = 0.3f;    

    public new ParticleSystem particleSystem;
    public float wiltTimerAlpha = 1;
    public float wiltTimerColor = 1;
    bool wilting;

    //Corrupt plants
    public bool corruptPlant;
    public float damageTreeTimer;
    public int damage;
    public float howOftenDamage;
    public GameObject tree;
    public Health treeHealth;
    public GameObject energystealer;

    [Header("AudioPlant")]
    public AudioManager plantSound;

    // Start is called before the first frame update
    private void Awake()
    {
        plantSound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void Start()
    {
        tree = GameObject.FindGameObjectWithTag("Tree");
        treeHealth = tree.GetComponent<Health>();
        particleSystem = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {       
        spriteRenderer.enabled = true;
        if (transform.localScale.x < growSize && growing && !wilting)
            transform.localScale += new Vector3(growSpeed, growSpeed, growSpeed) * Time.deltaTime;
        else            
            growing = false;
        
        if (wilting)
        {
            Wilt();
            energystealer.SetActive(false);
        }
        else
        {
            damageTreeTimer += Time.deltaTime;
            if (damageTreeTimer > howOftenDamage && GameValueManager.INSTANCE.treeIsALive)
            {
                energystealer.SetActive(true);
                damageTreeTimer = 0;
                treeHealth.TakeDamage(damage);
                PopUpText.INSTANCE.PopUpMessage("The Tree Is Taking Damage", Color.red);
            }            
        }
        if (tree == null)
        {
            Wilt();
        }
    }
    public void KillPlant()
    {        
        particleSystem.Play();
        Wilt();
        wilting = true;
       
       
    }
    public void Wilt()
    {
        Debug.Log("playing twig sound");
        wiltTimerAlpha -= (0.55f * Time.deltaTime);
        wiltTimerColor -= (0.70f * Time.deltaTime);
        spriteRenderer.color = new Color(wiltTimerColor, wiltTimerColor, wiltTimerColor, wiltTimerAlpha);        
        Destroy(gameObject, 4.5f);
    }        
}