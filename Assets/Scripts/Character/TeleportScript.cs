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
        //TeleportBackToTree();
    }
    public void TeleportBackToTree()
    {
        transform.position = treeScript.transform.position;         
    }   
}
