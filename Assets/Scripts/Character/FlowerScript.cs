using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloweScript : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
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
        if (Keyboard.current.spaceKey.wasPressedThisFrame == true)
        {
            particleSystem.Play();
            WiltTree();
            wilting = true;
        }
        if (wilting)
        {
            WiltTree();
        }
    }
    public void WiltTree()
    {             
        wiltTimerAlpha -= (0.35f * Time.deltaTime);   
        wiltTimerColor -= (0.60f * Time.deltaTime);
        spriteRenderer.color = new Color(wiltTimerColor, wiltTimerColor, wiltTimerColor, wiltTimerAlpha);
        Destroy(gameObject, 5.5f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            particleSystem.Play();
            WiltTree();
            wilting = true;
        }
    }
}
