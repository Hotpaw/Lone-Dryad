using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoFoosteps : MonoBehaviour
{
    public GameObject echo;

    private void Start()
    {
        echo.SetActive(false);
    }

    private void Update()
    {


    }


    public void OnTriggerEnter2D(Collider2D collider)
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

    }
    private void OnTriggerExit2D(Collider2D collider)
    {

        StopFootSteps();

    }
    public void FootSteps()
    {
        echo.SetActive(true);
    }

    public void StopFootSteps()
    {
        echo.SetActive(false);
    }

}
