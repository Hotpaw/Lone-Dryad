using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    Rigidbody2D rb2D;
    public TreeScript treeScript;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    public void TeleportBackToTree()
    {
        if (GameValueManager.INSTANCE.exhaustLevel == 3)
        {
            rb2D.position = treeScript.transform.position;
        }
    }   
}
