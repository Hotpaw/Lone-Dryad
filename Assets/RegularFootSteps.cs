using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RegularFootSteps : MonoBehaviour
{

    public GameObject footStep;
    // Start is called before the first frame update
    void Start()
    {
        
        footStep.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

       

        if (Input.GetKeyDown(KeyCode.D))
        {
            FootSteps();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            StopFootSteps();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            FootSteps();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            StopFootSteps();
        }

       //fixa if för gamepaden

    }

   public  void FootSteps()
    {
        footStep.SetActive(true);
    }

    public void StopFootSteps()
    {
        footStep.SetActive(false );
    }
}
