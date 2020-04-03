﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    private static DisplayManager instance;
    public static DisplayManager Instance { get { return instance; } }

    public List<GameObject> images;

    // TODO: Cleanup any of the above stuff that is unnecessary now


    // Inventory Display
    public GameObject inventoryBar;
    public Sprite emptySprite;


    // Text Display
    public Image textDisplayMask;
    public Text helpText;
    private bool showText = false;
    private bool transitioning = false;
    private string nextText = "";


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        float fillAmt = textDisplayMask.fillAmount;
        if ( showText )
        {
            if (fillAmt < 0.995f)
            {
                float interval = 0.05f;
                if (fillAmt > 0.5)
                {
                    interval = 0.07f;
                }
                if (fillAmt > 0.8)
                {
                    interval = 0.1f;
                }

                textDisplayMask.fillAmount = Mathf.Lerp(fillAmt, 1, interval);
            }
            else
            {
                textDisplayMask.fillAmount = 1;
            }
        }
        else if (fillAmt > 0.01f)
        {
            float interval = 0.05f;
            if (fillAmt < 0.5)
            {
                interval = 0.07f;
            }
            if (fillAmt < 0.2)
            {
                interval = 0.1f;
            }
            textDisplayMask.fillAmount = Mathf.Lerp(fillAmt, 0, interval);
        }
        else
        {
            textDisplayMask.fillAmount = 0;
            if (transitioning)
            {
                helpText.text = nextText;
                showText = true;
                transitioning = false;
            }
        }
    }

    public void SetHelpText(string text)
    {
        // An empty string indicates we are removing the display
        if ( text == "" )
        {
            showText = false;
            transitioning = false;
        }
        else
        {
            if (showText)
            {
                showText = false;
                transitioning = true;
                nextText = text;
            }
            else
            {
                helpText.text = text;
                showText = true;
            }
        }
    }

    public void SetImage(int pos, Sprite image)
    {
        // Inventory Bar
        //  > slot0
        //      > Item
        //  > slot 1
        //  > slot 2

        if ( image == null )
        {
            inventoryBar.transform.GetChild(pos).GetChild(0).GetComponent<Image>().sprite = emptySprite; 
        }
        else
        {
            inventoryBar.transform.GetChild(pos).GetChild(0).GetComponent<Image>().sprite = image;
        }
    }
}
