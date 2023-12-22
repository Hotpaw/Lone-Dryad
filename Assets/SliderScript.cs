using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public InputActionReference uiClick; //referera till UI input action navigering - click
    public InputActionReference uiNavigate; //referera till UI input action navigering - click
    private Slider uiSlider; //referera till ui sliders 
    Vector2 leftStickInput;
    public bool selected;

    ColorBlock colors;

    private void OnEnable()
    {
        uiSlider = GetComponent<Slider>();

        uiNavigate.action.Enable();
        uiClick.action.performed += OnUIClick;
        uiNavigate.action.performed += OnUIInteraction;
        uiNavigate.action.canceled += OnCancelUIInteraction;

        colors = uiSlider.colors;
    }

    private void OnDisable()
    {
        uiNavigate.action.Disable();
        uiClick.action.performed -= OnUIClick;
        uiNavigate.action.performed -= OnUIInteraction;
        uiNavigate.action.canceled -= OnCancelUIInteraction;
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
            colors.disabledColor = selected ? colors.pressedColor : colors.highlightedColor;
        else
            colors.disabledColor = colors.normalColor;

        uiSlider.colors = colors;

        if (selected)
        {
            // Choose the axis you want to use for adjustment (e.g., horizontal)
            float gamepadInput = leftStickInput.x;

            // Adjust the slider value based on the gamepad input
            uiSlider.value += gamepadInput * Time.deltaTime / 2;

            // Clamp the value to the slider's range
            uiSlider.value = Mathf.Clamp(uiSlider.value, uiSlider.minValue, uiSlider.maxValue);
        }
    }

    public void OnUIClick(InputAction.CallbackContext context)
    {
        if (EventSystem.current.currentSelectedGameObject != this.gameObject) return;

        selected = !selected;
        var nav = uiSlider.navigation;
        nav.mode = selected ? Navigation.Mode.None : Navigation.Mode.Explicit;
        uiSlider.navigation = nav;
    }


    private void OnUIInteraction(InputAction.CallbackContext context)
    {
        leftStickInput = context.ReadValue<Vector2>();
    }


    private void OnCancelUIInteraction(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();
        if (temp != Vector2.zero)
            leftStickInput = temp;
    }



    //private void OnUIInteraction(InputAction.CallbackContext context)
    //{
    //    // Check if the slider is interactable (optional)
    //    if (uiSlider.interactable)
    //    {
    //        // Get the value of the slider from the gamepad input
    //        float gamepadInput = context.ReadValue<float>();

    //        // Set the slider value based on the gamepad input
    //        uiSlider.value += gamepadInput;

    //        // You may want to clamp the value to the slider's range
    //        uiSlider.value = Mathf.Clamp(uiSlider.value, uiSlider.minValue, uiSlider.maxValue);
    //    }



    //}


    //public PlayerInput playerInput;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    if (playerInput == null) 
    //        return;

    //        if (playerInput.actions["YourActionButton"].triggered)
    //        {
    //            GameObject selectedObject = EventSystem.current.currentSelectedGameObject;


    //            if (selectedObject != null && selectedObject.GetComponent<Slider>() != null) 
    //            {

    //                //justera slider value
    //              Slider slider = selectedObject.GetComponent<Slider>();
    //               float inputValue = playerInput.actions["YourSliderAdjustmentAxis"].ReadValue<float>();
    //               slider.value += inputValue * Time.deltaTime; // Adjust based on input value

    //            }

    //        }


    //}

}
