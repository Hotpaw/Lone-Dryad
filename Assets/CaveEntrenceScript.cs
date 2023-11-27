using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CaveEntrenceScript : MonoBehaviour
{
    public bool inside;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!inside)
                player.transform.position = new Vector2(28, -7);
            else
                player.transform.position = new Vector2(25, -3.2f);
            inside = !inside;
        }

    }
}
