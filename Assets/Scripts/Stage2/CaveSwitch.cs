using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Assuming this is required for your specific implementation

public class CaveSwitch : InteractableObject
{
    public int mode;
    public bool once;
    List<GameObject> enemyList = new List<GameObject>();
    public static bool areSwitchesDeactivated = false;
    private static List<CaveSwitch> allCaveSwitches = new List<CaveSwitch>();

    void Start()
    {
        allCaveSwitches.Add(this);
    }

    void OnDestroy()
    {
        allCaveSwitches.Remove(this);
    }

    public override void Interact()
    {
        if (!once)
        {
            ChangePlayerLayer();
            once = true;
            ToggleOtherSwitches();
            HandleCullingAndMovement();
            StartCoroutine(Wait());
        }
    }

    private void ToggleOtherSwitches()
    {
        if (!areSwitchesDeactivated)
        {
            foreach (var caveSwitch in allCaveSwitches)
            {
                if (caveSwitch != this)
                {
                    caveSwitch.gameObject.SetActive(false);
                }
            }
            areSwitchesDeactivated = true;
        }
        else
        {
            foreach (var caveSwitch in allCaveSwitches)
            {
                caveSwitch.gameObject.SetActive(true);
            }
            areSwitchesDeactivated = false;
        }
    }

    private void HandleCullingAndMovement()
    {
       
        if (cullBackground.INSTANCE.Backgrounds[0].activeInHierarchy)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                enemyList.Add(enemy);
                enemy.gameObject.SetActive(false);
            }
            Debug.Log("Switch start Activated");
            
            cullBackground.INSTANCE.CullingModeCall(mode);
        }
        else
        {
            cullBackground.INSTANCE.CullingModeCall(0);
            ReactivateEnemies();
        }
    }

    private void ChangePlayerLayer()
    {
        var movementGameObject = FindAnyObjectByType<Movement>().gameObject;

        // Debugging: Log the current layer before changing
        Debug.Log("Current Layer: " + movementGameObject.layer);

        if (movementGameObject.layer == 3)
        {
            movementGameObject.layer = 11;
            Debug.Log("Layer changed to 11");
        }
        else if (movementGameObject.layer == 11)
        {
            movementGameObject.layer = 3;
            Debug.Log("Layer changed to 3");
        }
        else
        {
            Debug.LogWarning("Layer was neither 3 nor 11. Current layer: " + movementGameObject.layer);
        }
    }

    private void ReactivateEnemies()
    {
        foreach (var enemy in enemyList)
        {
            if (enemy != null)
            {
                enemy.gameObject.SetActive(true);
            }
        }
        enemyList.Clear();
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        once = false;
    }

    // Implement FindAnyObjectByType if it's not already defined elsewhere
    private T FindAnyObjectByType<T>() where T : Object
    {
        return FindObjectOfType<T>();
    }
}