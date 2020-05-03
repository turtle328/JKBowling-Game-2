using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Scene3Manager : MonoBehaviour
{

    public Texture2D page1;
    public Texture2D page2;
    public Texture2D page3;
    const int pageWidth = 675;
    const int pageHeight = 900;
    public Texture2D puzzle1;
    private int puzzle1Width = 600;
    private int puzzle1Height = 50;
    public Texture2D puzzle2;
    private int puzzle2Width = 620;
    private int puzzle2Height = 50;
    public Texture2D puzzle3;
    private int puzzle3Width = 600;
    private int puzzle3Height = 50;
    public Texture2D p2_1;
    private int p2_1Width = 675;
    private int p2_1Height = 900;
    public Texture2D p2_2;
    private int p2_2Width = 675;
    private int p2_2Height = 900;
    public Texture2D p2_3;
    private int p2_3Width = 675;
    private int p2_3Height = 900;
    public Texture2D p2_4;
    private int p2_4Width = 675;
    private int p2_4Height = 900;
    public Texture2D minus;
    private int minusWidth = 50;
    private int minusHeight = 10;
    public Texture2D plus;
    private int plusWidth = 675;
    private int plusHeight = 900;
    public Texture2D phone;
    private int phoneWidth = 150;
    private int phoneHeight = 320;
    public Texture2D signCode;
    private int signCodeWidth = 100;
    private int signCodeHeight = 100;
    //public Texture2D nextButton;
    //private int nextButtonWidth = 675;
    //private int nextButtonHeight = 900;
    //public Texture2D prevButton;
    //private int prevButtonWidth = 675;
    //private int prevButtonHeight = 900;
    public GameObject player;

    public int page = 2;

    public GameObject prevButton;
    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<FirstPersonController>().enabled = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnGUI()
    {
        if (page == 1)
        {
            float xMin1 = (Screen.width / 2) - pageWidth / 2;
            float yMin1 = (Screen.height / 2) - pageHeight / 2;
            GUI.DrawTexture(new Rect(xMin1, yMin1, pageWidth, pageHeight), page1);
            GUI.DrawTexture(new Rect(xMin1 + 30, yMin1 + 700, puzzle1Width, puzzle1Height), puzzle1);
        }
        else if (page == 2)
        {
            float xMin2 = (Screen.width / 2) - pageWidth / 2;
            float yMin2 = (Screen.height / 2) - pageHeight / 2;
            GUI.DrawTexture(new Rect(xMin2, yMin2, pageWidth, pageHeight), page2);
            GUI.DrawTexture(new Rect(yMin2 + 680, yMin2 + 780, puzzle2Width, puzzle2Height), puzzle2);
            GUI.DrawTexture(new Rect(yMin2 + 700, yMin2 + 450, phoneWidth, phoneHeight), phone);
            GUI.DrawTexture(new Rect(yMin2 + 1100, yMin2 + 650, signCodeWidth, signCodeHeight), signCode);
        }
        else if (page == 3)
        {
            float xMin3 = (Screen.width / 2) - pageWidth / 2;
            float yMin3 = (Screen.height / 2) - pageHeight / 2;
            GUI.DrawTexture(new Rect(xMin3, yMin3, pageWidth, pageHeight), page3);
            GUI.DrawTexture(new Rect(yMin3 + 680, yMin3 + 700, puzzle3Width, puzzle3Height), puzzle3);
        }







        //float xMin = (Screen.width / 2) - pageWidth / 2;
        //float yMin = (Screen.height / 2) - pageHeight / 2;
        //if (page == 1)
        //{
        //    GUI.DrawTexture(new Rect(xMin, xMin, pageWidth, pageHeight), page1);
        //    GUI.DrawTexture(new Rect(yMin + 30, yMin + 700, puzzleWidth, puzzleHeight), puzzle1);
        //}
        //else if (page == 2)
        //{
        //    GUI.DrawTexture(new Rect(xMin, xMin, pageWidth, pageHeight), page2);
        //    GUI.DrawTexture(new Rect(yMin + 30, yMin + 700, puzzleWidth, puzzleHeight), puzzle2);
        //}
        //else if (page == 3)
        //{
        //    GUI.DrawTexture(new Rect(xMin, xMin, pageWidth, pageHeight), page3);
        //    GUI.DrawTexture(new Rect(yMin + 30, yMin + 700, puzzleWidth, puzzleHeight), puzzle3);
        //}


    }
}
