using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLine : MonoBehaviour
{
   
   
    public float radius;
    LineRenderer lineRenderer;
    public GameObject previous;
    // Start is called before the first frame update
    bool reach = false;
    void Start()
    {
       
      
      
    }
    private void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, previous.transform.position);
    }
}
