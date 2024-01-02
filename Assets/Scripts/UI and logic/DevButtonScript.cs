using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DevButtonScript : MonoBehaviour
{
    public static DevButtonScript INSTANCE;
    public GameObject player;
    public Vector2 checkPoint;
    public float playerY;
    public float playerX;
    Health health;
    public bool stage2;
    public GameObject settings;
    // Start is called before the first frame update
    void Start()
    {
       
      if(GameObject.FindGameObjectWithTag("Tree").GetComponent<Health>() != null)
        {

        health = GameObject.FindGameObjectWithTag("Tree").GetComponent<Health>();
        }
        else
        {
            Debug.LogError("Tree Reference Is missing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
        {
            StopAllCoroutines();
            if (stage2)
            {
               // FIXA CHECKPOINT
                GameValueManager.INSTANCE.thePowerToThrowNuts = true;
                TreeState2.INSTANCE.enemyWaveActive = true;
                GameValueManager.INSTANCE.progressActive = true;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
           
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
            PlayerPrefs.Save();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            playerY = PlayerPrefs.GetFloat("PlayerY");
            playerX = PlayerPrefs.GetFloat("PlayerX");
            player.transform.position = new Vector2(playerX, playerY);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Time.timeScale -= 0.25f;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Time.timeScale += 0.25f;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            health.TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            health.Heal(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Gamepad.current != null && Gamepad.current.selectButton.wasPressedThisFrame) 
        {
            ToggleSettings();
        }
    }
    public void ToggleSettings()
    {
        if(settings != null)
        {
            if(settings.activeInHierarchy)
            {
                settings.gameObject.SetActive(false);
            }
            else
            {
                settings.gameObject.SetActive(true);
            }
        }else
            Debug.LogError("Settings Window referenc is null");
    }
}
