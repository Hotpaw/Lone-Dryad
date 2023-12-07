using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class cave : MonoBehaviour
{
    float playerfollowraidus;
    

    private void Update()
    {
        if(Vector2.Distance(transform.position, FindAnyObjectByType<Movement>().gameObject.transform.position) < playerfollowraidus)
        {
            transform.position = Vector2.MoveTowards(transform.position,FindAnyObjectByType<Movement>().gameObject.transform.position,Mathf.Infinity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            cullBackground.INSTANCE.ChangeBackground(1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cullBackground.INSTANCE.ChangeBackground(0);
        }
    }
}
