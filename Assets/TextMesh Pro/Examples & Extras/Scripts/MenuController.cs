using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    //[SerializeField] private MenuController m_MenuController;
    //[SerializeField] public InputActionReference menuButton;
    public GameObject menuWindow;
    private bool menuOpen = true;
    private InputAction playerNavigation;

    public List<Button> menuButtons = new List<Button>();

    public InputActionMap playerNavigationMap;

    public void Awake()
    {
        //Button[] menuButtons = FindObjectByType<Button>();
        menuButtons.AddRange(menuButtons);
        playerNavigation = new InputAction("Player/MenuNavigation");

        playerNavigation.performed += ctx => OnNavigationInput(ctx.ReadValue<Vector2>()); //ctx är callbackcontext
    }


    private void OnEnable()
    {
        playerNavigation.Enable();
    }

   private void OnDisable() 
   {
    playerNavigation?.Disable();
   }
    private void OnNavigationInput(Vector2 inputVector)
    {
        float verticalInput = inputVector.y;


        if (verticalInput > 0) 
        {
            //navigera up
            Navigate(-1);
        
        }
        else if (verticalInput < 0) 
        {
          Navigate(1);
        
          //navigera ner 
        }

    }
    private void Navigate(int direction)
    {
        int currentButtonIndex = GetCurrentButtonIndex(); //för att veta vilken knapp via dess index
       //deselect nuvarande knapp
        int nextIndex = (currentButtonIndex + direction + menuButtons.Count); //beräkna nästa knapp index baserat på riktningen 
        menuButtons[nextIndex].Select(); //välj knappen
    }
    private int GetCurrentButtonIndex()
    {
        int buttonIndex = 0;
        return buttonIndex;
    }
}
