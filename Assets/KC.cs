using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KC : MonoBehaviour
{
    public int KCNR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (KCNR)
        {
            case 0:
                if(Input.GetKeyDown(KeyCode.UpArrow)) 
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 1:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 3:
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 5:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 6:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 7:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 8:
                if (Input.GetKeyDown(KeyCode.B))
                {
                    KCNR++;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;

            case 9:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    PopUpText.INSTANCE.PopUpMessage("Konami Code Input! Enter superhero mood!", Color.red);
                    GameValueManager.INSTANCE.KC = true;
                }
                else if (Input.anyKeyDown)
                {
                    KCNR = 0;
                }
                break;    
        }
        if (Input.GetKeyDown(KeyCode.Return) && GameValueManager.INSTANCE.KC)
        {
            GameValueManager.INSTANCE.KC = false;
        }
    }
}
