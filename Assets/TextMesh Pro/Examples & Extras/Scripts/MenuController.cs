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
    //public GameObject menuWindow;
    //private bool menuOpen = true;

    public List<Button> menuButtons = new List<Button>();

    public PlayerInput playerNavigation;

    int selectIndex = 0;

    public void Awake()
    {
        

    }


   // private void OnEnable()
   // {
   //    playerNavigation.Enable();
   // }

   //private void OnDisable() 
   //{
   // playerNavigation.Disable();
   //}











    //Button[] foundButtons = FindObjectsOfType<Button>();
    //menuButtons.AddRange(menuButtons);
    //playerNavigation.performed += ctx => OnNavigationInput(ctx.ReadValue<Vector2>()); //ctx �r callbackcontext
    ////playerNavigation = new InputAction("Player/MenuNavigation");
    ////playerNavigation.AddBinding("<Gamepad>/LeftStick/Up"); 
    ////playerNavigation.AddBinding("<Gamepad>/LeftStick/Down"); 


    //private void MoveSelection(float direction)
    //{
    //    int buttonCount = menuButtons.Count; //riktning up �r positiv, riktning ner negativ
    //    menuButtons[selectIndex].OnDeselect(null); //deselect kallad f�r s�ga till ui att den f�rra knappen ej l�ngre �r vald

    //    selectIndex =(selectIndex + buttonCount + (int) direction) % buttonCount; //uppdatera nya index baserad p� riktning
    //    menuButtons[selectIndex].OnSelect(null); //v�lj den nya highlightade knappen. 

    //}





















    //private void OnNavigationInput(Vector2 inputVector)
    //{
    //    float verticalInput = inputVector.y;


    //    if (verticalInput > 0) 
    //    {
    //        //navigera up
    //        Navigate(-1);

    //    }
    //    else if (verticalInput < 0) 
    //    {
    //      Navigate(1);

    //      //navigera ner 
    //    }

    //}
    //private void Navigate(int direction)
    //{
    //    int currentButtonIndex = GetCurrentButtonIndex(); //f�r att veta vilken knapp via dess index
    //    menuButtons[currentButtonIndex].Deselect (); //deselect nuvarande knapp
    //    int nextIndex = (currentButtonIndex + direction + menuButtons.Count); //ber�kna n�sta knapp index baserat p� riktningen 
    //    menuButtons[nextIndex].Select(); //v�lj knappen
    //}
    //private int GetCurrentButtonIndex()
    //{
    //    int buttonIndex = 0;
    //    return buttonIndex;
    //}
}
