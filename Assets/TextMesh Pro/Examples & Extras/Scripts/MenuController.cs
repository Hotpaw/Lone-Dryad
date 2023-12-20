using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{

    //[SerializeField] private MenuController m_MenuController;
    [SerializeField] public InputActionReference menuButton;
    public GameObject menuWindow;
    private bool menuOpen = true;
    
    // Start is called before the first frame update
    void Start()
    {
        menuButton.action.started += MenuToggle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MenuToggle(InputAction.CallbackContext obj) 
    {
    
      menuOpen = !menuOpen;
      menuWindow.SetActive(menuOpen);
    
    }

    private void OnDestroy()
    {
        menuButton.action.started -= MenuToggle;
    }
}
