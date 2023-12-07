using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PopUpText : MonoBehaviour
{
    public static PopUpText INSTANCE;
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
        popUpText.gameObject.SetActive(true);
        popUpText.color = color;
        popUpText.text = message;
        yield return new WaitForSeconds(timer);
        popUpText.gameObject.SetActive(false);

    }
}
