using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    // Singleton Instance Variable
    public static DisplayManager Instance { get; private set; }

    // Inventory Display
    public GameObject inventoryBar;
    public Sprite emptySprite;


    // Text Display
    public Image textDisplayMask;
    public TMP_Text helpText;
    public TMP_Text eventText;
    private bool showText = false;
    private bool transitioning = false;
    private string nextText = "";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        inventoryBar.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
    }

    void Update()
    {
        //textDisplayMask.fillAmount = 1;
        AnimateText();
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
    
    /// <summary>
    /// Changes selected inventory position color to yellow if highlight is true.
    /// Otherwise return it to white.
    /// </summary>
    /// <param name="pos">Position of the inventory index</param>
    /// <param name="highlight">Highlight or turn color back to white?</param>
    public void ToggleHighlight(int pos, bool highlight)
    {
        if (highlight)
        {
            inventoryBar.transform.GetChild(pos).GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            inventoryBar.transform.GetChild(pos).GetComponent<Image>().color = Color.white;
        }
    }

    public void TriggerEventText(string text)
    {
        Animator textAnim = eventText.GetComponent<Animator>();
        eventText.text = text;
        textAnim.SetTrigger("TriggerText");
    }

    private void AnimateText()
    {
        float fillAmt = textDisplayMask.fillAmount;
        if (showText)
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

}
