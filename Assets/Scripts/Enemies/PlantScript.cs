using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlantScript : MonoBehaviour
{
    public float growTimer;
    public SpriteRenderer spriteRenderer;
    public bool growing;

    public float growSize;
    public float growSpeed;
    public float growUpWhen;

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

    // Start is called before the first frame update
    void Start()
    {
        tree = GameObject.FindGameObjectWithTag("Tree");
        treeHealth = tree.GetComponent<Health>();
        particleSystem = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        growSize = Random.Range(0.3f, 0.7f);
        growSpeed = Random.Range(0.1f, 0.4f);
        growUpWhen = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        growTimer += Time.deltaTime;
        if (growTimer > growUpWhen)
        {
            growing = true;
            spriteRenderer.enabled = true;
            if (transform.localScale.x < growSize && growing && !wilting)
                transform.localScale += new Vector3(growSpeed, growSpeed, growSpeed) * Time.deltaTime;
            else
            {
                growing = false;
            }
        }
        //if (Keyboard.current.spaceKey.wasPressedThisFrame == true)
        //{
        //    particleSystem.Play();
        //    WiltTree();
        //    wilting = true;
        //}
        if (wilting)
        {
            WiltTree();
            energystealer.SetActive(false);
        }
        if (corruptPlant && !wilting)
        {
            damageTreeTimer += Time.deltaTime;
            if (damageTreeTimer > howOftenDamage && GameValueManager.INSTANCE.treeIsALive)
            {
                energystealer.SetActive(true);
                damageTreeTimer = 0;
                treeHealth.TakeDamage(damage);
                PopUpText.INSTANCE.PopUpMessage("a parasitic plant is stealing the lifeenergy from the tree", Color.red);
            }
            GameValueManager.INSTANCE.progressScore -= 0.2f * Time.deltaTime;
        }
        if (tree == null)
        {
            WiltTree();
        }
    }
    public void WiltTree()
    {
        wiltTimerAlpha -= (0.55f * Time.deltaTime);
        wiltTimerColor -= (0.70f * Time.deltaTime);
        spriteRenderer.color = new Color(wiltTimerColor, wiltTimerColor, wiltTimerColor, wiltTimerAlpha);
        Destroy(gameObject, 4.5f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PopUpText.INSTANCE.PopUpMessage("Press E to get rid of this evil plant", Color.magenta);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Keyboard.current.eKey.IsActuated() && Gamepad.current.buttonEast.IsActuated())
            {
                particleSystem.Play();
                WiltTree();
                wilting = true;
            }
        }
    }
}