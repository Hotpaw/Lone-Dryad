using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cullBackground : MonoBehaviour
{
    public static cullBackground INSTANCE;
    public GameObject[] Backgrounds;
    bool used = false;
    private void Start()
    {
        INSTANCE = this;
    }
    public void CullingModeCall(int a)
    {
        if (!used)
        {

            StartCoroutine(cullingMode(a));
        }
        else return;
    }
    public void ChangeBackground(int a)
    {
        foreach (var item in Backgrounds)
        {
            item.gameObject.SetActive(false);
        }

        if(a == 0)
        {
            CaveSwitch[] switches = FindObjectsOfType<CaveSwitch>();
            foreach (CaveSwitch sw in switches)
            {
                sw.gameObject.GetComponent<InteractWith>().interactableDescription = "Enter";
            }
        }
        else
        {
            CaveSwitch[] switches = FindObjectsOfType<CaveSwitch>();
            foreach (CaveSwitch sw in switches)
            {
                sw.gameObject.GetComponent<InteractWith>().interactableDescription = "Exit";
            }
        }

        if (a == 0)
        {
            Backgrounds[0].SetActive(true);            
        }
        if (a == 1)
        {
            Backgrounds[1].SetActive(true);
        }
        if (a == 2)
        {
            Backgrounds[2].SetActive(true);
        }
        if (a == 3)
        {
            Backgrounds[3].SetActive(true);
        }
        CaveSwitch[] switches1 = FindObjectsOfType<CaveSwitch>();
        foreach (CaveSwitch sw in switches1)
        {
            sw.gameObject.SetActive(false);
            sw.gameObject.SetActive(true);
        }
    }
    IEnumerator cullingMode(int a)
    {
        used = true;
        ChangeBackground(a);
        yield return new WaitForSeconds(0.5f);
        used = false;
    }
}
