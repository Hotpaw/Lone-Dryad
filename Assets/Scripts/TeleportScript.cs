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
    private void Update()
    {
        if (GameValueManager.INSTANCE.exhaustLevel == GameValueManager.INSTANCE.maxExhaustLevel)
        {
            TeleportBackToTree();
        }
    }
    public void TeleportBackToTree()
    {
        rb2D.position = treeScript.transform.position;         
    }   
}
