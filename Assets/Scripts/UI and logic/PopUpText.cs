using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PopUpText : MonoBehaviour
{
    public static PopUpText INSTANCE;
    public Transform[] windowPosition;
    public GameObject popUpDialogue;
    public TextMeshProUGUI popUpText;
    public int timer;
    private void Awake()
    {
     
        INSTANCE = this;
      

        if (timer == 0)
        {
            timer = 1;
        }
    }
    // Start is called before the first frame update
    public void PopUpMessage(string message, Color color)
    {
        StartCoroutine(showText(message, color));
    }
    IEnumerator showText(string message, Color color)
    {
        popUpDialogue.gameObject.transform.position = windowPosition[0].position;
        popUpDialogue.gameObject.SetActive(true);
        popUpText.color = color;
        popUpText.text = message;
        yield return new WaitForSeconds(timer);
        popUpDialogue.gameObject.SetActive(false);

    }
    public void PopUpMessage(string message, Color color, float duration)
    {
        StartCoroutine(showText(message, color, duration));
    }
    IEnumerator showText(string message, Color color, float duration)
    {
        popUpDialogue.gameObject.transform.position = windowPosition[0].position;
        popUpDialogue.gameObject.SetActive(true);
        popUpText.color = color;
        popUpText.text = message;
        yield return new WaitForSeconds(duration);
        popUpDialogue.gameObject.SetActive(false);

    }
    public void PopUpMessage(string message, Color color, float duration, bool position)
    {
        StartCoroutine(showText(message, color, duration, position));
    }
    IEnumerator showText(string message, Color color, float duration, bool position)
    {
        if(position == true)
        {
            popUpDialogue.gameObject.transform.position = windowPosition[1].position;
        }
        else
        {
            popUpDialogue.gameObject.transform.position = windowPosition[0].position;
        }
        popUpDialogue.gameObject.SetActive(true);
        popUpText.color = color;
        popUpText.text = message;
        yield return new WaitForSeconds(duration);
       
        popUpDialogue.gameObject.SetActive(false);
       
    }
    public void PopUpMessage(string message, Color color, float duration, bool position, bool Priority)
    {
        if(Priority == true)
        {
            popUpDialogue.SetActive(false);
            StartCoroutine(showText(message, color, duration, position, Priority));
        }
    
    }
    IEnumerator showText(string message, Color color, float duration, bool position, bool Priority)
    {
        if (position == true)
        {
            popUpDialogue.gameObject.transform.position = windowPosition[1].position;
        }
        else
        {
            popUpDialogue.gameObject.transform.position = windowPosition[0].position;
        }
        popUpDialogue.gameObject.SetActive(true);
        popUpText.color = color;
        popUpText.text = message;
        yield return new WaitForSeconds(duration);

        popUpDialogue.gameObject.SetActive(false);

    }
}
