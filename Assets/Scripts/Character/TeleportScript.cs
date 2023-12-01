using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public TreeScript treeScript;
    // Start is called before the first frame update
    
    private void Update()
    {
        if (GameValueManager.INSTANCE.exhaustLevel == 2)
        {
            TeleportBackToTree();
            GameValueManager.INSTANCE.exhaustLevel = 0;
        }
    }
    public void TeleportBackToTree()
    {
        transform.position = treeScript.transform.position;         
    }   
}
