
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blackOut : MonoBehaviour
{
    public GameObject blackOutPanel;
    public bool startBlackOut;
    public bool endBlackOut;

    //Fade
    public float alphaColor;
    public float fadeSpeed;
    public float fadedTime;
    public float fadeForSec;
    private bool isTransitioning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransitioning)
        {
            PerformBlackOutTransition();
        }
        FadeInFadeOut();
    }

    private void FadeInFadeOut()
    {
        blackOutPanel.GetComponent<Image>().color = new Color(0, 0, 0, alphaColor);
        if (startBlackOut)
        {
            alphaColor += fadeSpeed * Time.deltaTime;
            if (alphaColor > 1)
            {
                alphaColor = 1;

            }
            if (alphaColor >= 1)
                fadedTime += Time.deltaTime; //Starting timer

            if (fadedTime > fadeForSec)  //When timer is more then the set time, it will start to fade back
            {
                startBlackOut = false;
                endBlackOut = true;
                fadedTime = 0;
            }
        }
        if (endBlackOut)
        {
            alphaColor -= fadeSpeed * Time.deltaTime;
            if (alphaColor < 0)
            {
                alphaColor = 0;
                endBlackOut = false;
            }
        }
    }

    public void StartBlackOutTransition()
    {
        if (!isTransitioning)
        {
            alphaColor = 0f;
            isTransitioning = true;
        }
    }

    private void PerformBlackOutTransition()
    {
        alphaColor += fadeSpeed * Time.deltaTime;
        alphaColor = Mathf.Clamp(alphaColor, 0, 1);
        blackOutPanel.GetComponent<Image>().color = new Color(0, 0, 0, alphaColor);

        if (alphaColor >= 1)
        {
            isTransitioning = false;
        }
    }
}
