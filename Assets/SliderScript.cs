using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerInput == null) 
            return;

            if (playerInput.actions["YourActionButton"].triggered)
            {
                GameObject selectedObject = EventSystem.current.currentSelectedGameObject;


                if (selectedObject != null && selectedObject.GetComponent<Slider>() != null) 
                {
                  
                    //justera slider value
                  Slider slider = selectedObject.GetComponent<Slider>();
                   float inputValue = playerInput.actions["YourSliderAdjustmentAxis"].ReadValue<float>();
                   slider.value += inputValue * Time.deltaTime; // Adjust based on input value

                }

            }


    }
}
