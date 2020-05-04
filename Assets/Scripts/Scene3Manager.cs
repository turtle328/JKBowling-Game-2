using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine;

public class Scene3Manager : MonoBehaviour
{
    // instances of the pages
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject lastPage;

    // next and prev buttons
    public GameObject prevButton;
    public GameObject nextButton;
    // minus and plus 
    public GameObject plusB0;
    public GameObject plusB1;
    public GameObject plusB2;
    public GameObject minusB0;
    public GameObject minusB1;
    public GameObject minusB2;
    // puzzle 1 inputs
    public GameObject inputP1_1;
    public GameObject inputP1_2;
    public GameObject inputP1_3;
    public GameObject inputP1_4;
    public GameObject inputP1_Answer;
    // puzzle 2 input
    public GameObject inputP2_Answer;
    // puzzle 3 inputs
    public GameObject inputP3_1;
    public GameObject inputP3_2;
    public GameObject inputP3_3;
    public GameObject inputP3_4;
    public GameObject inputP3_Answer;
    // final input
    public GameObject inputFinal;
    
    public GameObject player;
    public GameObject diary;

    // counter for pages
    public int page = 0;

    public bool diaryOpen = false;

    // access to the inventory
    public Inventory inven;

    // page dimension constants
    const int pageWidth = 675;
    const int pageHeight = 900;
    // puzzle textures and dimensions
    public Texture2D puzzle1;
    private int puzzle1Width = 600;
    private int puzzle1Height = 50;
    public Texture2D puzzle2;
    private int puzzle2Width = 620;
    private int puzzle2Height = 50;
    public Texture2D puzzle3;
    private int puzzle3Width = 600;
    private int puzzle3Height = 50;
    // extra textures for puzzles
    public Texture2D minusCode;
    public Texture2D plusCode;
    private int mpWidth = 200;
    private int mpHeight = 50;
    public Texture2D p2_1;
    private int p2_1Width = 25;
    private int p2_1Height = 25;
    public Texture2D p2_2;
    private int p2_2Width = 25;
    private int p2_2Height = 25;
    public Texture2D p2_3;
    private int p2_3Width = 25;
    private int p2_3Height = 25;
    public Texture2D p2_4;
    private int p2_4Width = 25;
    private int p2_4Height = 25;
    public Texture2D phone;
    private int phoneWidth = 150;
    private int phoneHeight = 320;
    public Texture2D signCode;
    private int signCodeWidth = 100;
    private int signCodeHeight = 100;

    // Start is called before the first frame update
    void Start()
    {
        // set everything to false
        PageSetFalse();

        nextButton.SetActive(false);
        prevButton.SetActive(false);
        inputFinal.SetActive(false);

        ButtonPMFalse();

        Input1False();
        Input2False();
        Input3False();

    }

    // Update is called once per frame
    void Update()
    {
        // check if the player has the diary, and if they open it or close it
        if (Input.GetKeyDown(KeyCode.O))
        {
            for (int i = 0; i < Inventory.MAX_INVENTORY; i++)
            {
                if (inven.inventory[i] == diary)
                {
                    if (diaryOpen)
                    {
                        player.GetComponent<FirstPersonController>().enabled = true;
                        PageSetFalse();
                        Input1False();
                        Input2False();
                        Input3False();
                        ButtonPMFalse();
                        nextButton.SetActive(false);
                        prevButton.SetActive(false);
                        inputFinal.SetActive(false);
                        // make it so the cursor is invisble
                        Cursor.visible = false;
                        diaryOpen = false;
                        page = 0;
                    }
                    else
                    {
                        player.GetComponent<FirstPersonController>().enabled = false;
                        nextButton.SetActive(true);
                        prevButton.SetActive(true);
                        // set these true so it isn't called repetedly in onGUI
                        minusB0.SetActive(true);
                        minusB1.SetActive(true);
                        minusB2.SetActive(true);
                        // make it so the cursor is visable and can be moved
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        diaryOpen = true;
                        page = 1;
                    }

                }
            }
        }

        // close the book when they complete the final puzzle
        if (page == 0)
        {
            player.GetComponent<FirstPersonController>().enabled = true;
            PageSetFalse();
            Input1False();
            Input2False();
            Input3False();
            ButtonPMFalse();
            nextButton.SetActive(false);
            prevButton.SetActive(false);
            inputFinal.SetActive(false);
            // make it so the cursor is invisble
            Cursor.visible = false;
            diaryOpen = false;
            page = 0;
        }


        // print the diary help text
        if (diary != null && inven.GetCurrentItem() == diary)
        {
            DisplayManager.Instance.SetHelpText("Press 'O' to toggle Diary");
        }
    }


    void OnGUI()
    {
        if (page == 1)
        {
            float xMin1 = (Screen.width / 2) - pageWidth / 2;
            float yMin1 = (Screen.height / 2) - pageHeight / 2;
            // make sure what isn't meant to be there isn't
            PageSetFalse();
            Input2False();
            Input3False();
            inputFinal.SetActive(false);
            // make sure what is meant to be there is
            Puzzle1Set();

            // draw the standard texture2ds
            GUI.DrawTexture(new Rect(xMin1 + 30, yMin1 + 700, puzzle1Width, puzzle1Height), puzzle1);
            GUI.DrawTexture(new Rect(xMin1 + 30, yMin1 + 620, mpWidth, mpHeight), minusCode);
            GUI.DrawTexture(new Rect(xMin1 + 300, yMin1 + 620, mpWidth, mpHeight), plusCode);
        }
        else if (page == 2)
        {
            float xMin2 = (Screen.width / 2) - pageWidth / 2;
            float yMin2 = (Screen.height / 2) - pageHeight / 2;
            // make sure what isn't meant to be there isn't
            PageSetFalse();
            Input1False();
            Input3False();
            inputFinal.SetActive(false);
            ButtonPMFalse();
            // make sure what is meant to be there is
            page2.SetActive(true);
            inputP2_Answer.SetActive(true);

            // draw the standard texture2ds
            GUI.DrawTexture(new Rect(xMin2, yMin2 + 780, puzzle2Width, puzzle2Height), puzzle2);
            GUI.DrawTexture(new Rect(xMin2 + 60, yMin2 + 450, phoneWidth, phoneHeight), phone);
            GUI.DrawTexture(new Rect(xMin2 + 400, yMin2 + 650, signCodeWidth, signCodeHeight), signCode);

        }
        else if (page == 3)
        {
            float xMin3 = (Screen.width / 2) - pageWidth / 2;
            float yMin3 = (Screen.height / 2) - pageHeight / 2;
            // make sure what isn't meant to be there isn't
            PageSetFalse();
            Input1False();
            Input2False();
            ButtonPMFalse();
            inputFinal.SetActive(false);
            // make sure what is meant to be there is
            Puzzle3Set();

            // draw the standard texture2ds
            GUI.DrawTexture(new Rect(yMin3 + 680, yMin3 + 700, puzzle3Width, puzzle3Height), puzzle3);
            GUI.DrawTexture(new Rect(xMin3 + 150, yMin3 + 20, p2_1Width, p2_1Height), p2_1);
            GUI.DrawTexture(new Rect(xMin3 + 460, yMin3 + 180, p2_2Width, p2_2Height), p2_2);
            GUI.DrawTexture(new Rect(xMin3 + 600, yMin3 + 800, p2_3Width, p2_3Height), p2_3);
            GUI.DrawTexture(new Rect(xMin3 + 20, yMin3 + 600, p2_4Width, p2_4Height), p2_4);
        }
        else if (page == 4)
        {
            Input1False();
            Input2False();
            Input3False();
            PageSetFalse();
            ButtonPMFalse();
            lastPage.SetActive(true);
            inputFinal.SetActive(true);
        }
    }
    // set all the properties for puzzle 1 and 2 to true respectivly
    private void Puzzle1Set()
    {
        page1.SetActive(true);
        inputP1_1.SetActive(true);
        inputP1_2.SetActive(true);
        inputP1_3.SetActive(true);
        inputP1_4.SetActive(true);
        inputP1_Answer.SetActive(true);
    }

    private void Puzzle3Set()
    {
        inputP3_1.SetActive(true);
        inputP3_2.SetActive(true);
        inputP3_3.SetActive(true);
        inputP3_4.SetActive(true);
        inputP3_Answer.SetActive(true);
        page3.SetActive(true);
    }
    // set all the pages to false
    private void PageSetFalse()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        lastPage.SetActive(false);
    }

    // set all the inputs of puzzle 1 to false
    private void Input1False()
    {
        inputP1_1.SetActive(false);
        inputP1_2.SetActive(false);
        inputP1_3.SetActive(false);
        inputP1_4.SetActive(false);
        inputP1_Answer.SetActive(false);
    }
    // set all the inputs of puzzle 2 to false
    private void Input2False()
    {
        inputP2_Answer.SetActive(false);
    }
    // set all the inputs of puzzle 3 to false
    private void Input3False()
    {
        inputP3_1.SetActive(false);
        inputP3_2.SetActive(false);
        inputP3_3.SetActive(false);
        inputP3_4.SetActive(false);
        inputP3_Answer.SetActive(false);
    }

    // set all the plus and minus buttons to false
    private void ButtonPMFalse()
    {
        plusB0.SetActive(false);
        plusB1.SetActive(false);
        plusB2.SetActive(false);
        minusB0.SetActive(false);
        minusB1.SetActive(false);
        minusB2.SetActive(false);
    }

    // when the user presses a "-" or "+" switch it to the other
    public void SwitchSign0()
    {
        if (minusB0.activeSelf)
        {
            plusB0.SetActive(true);
            minusB0.SetActive(false);
        }
        else
        {
            plusB0.SetActive(false);
            minusB0.SetActive(true);
        }
    }
    public void SwitchSign1()
    {
        if (minusB1.activeSelf)
        {
            plusB1.SetActive(true);
            minusB1.SetActive(false);
        }
        else
        {
            plusB1.SetActive(false);
            minusB1.SetActive(true);
        }
    }

    public void SwitchSign2()
    {
        if (minusB2.activeSelf)
        {
            plusB2.SetActive(true);
            minusB2.SetActive(false);
        }
        else
        {
            plusB2.SetActive(false);
            minusB2.SetActive(true);
        }
    }


    // code for handeling all of the puzzle answers in input fields
    public void Puzzl1Answer(string answer)
    {
        if (answer == "08")
        {
            nextPage();
        }
    }

    public void Puzzl2Answer(string answer)
    {
        if (answer == "17")
        {
            nextPage();
        }
    }

    public void Puzzl3Answer(string answer)
    {
        if (answer == "97")
        {
            nextPage();
        }
    }

    public void FinalAnswer(string answer)
    {
        if (answer == "08/17/97")
        {
            // close the diary
            page = 0;
            inven.RemoveCurrentItem();
        }
    }
    // go to the next or prev page when the buttons are clicked
    public void nextPage()
    {
        if (page == 4)
        {
            page = 1;
        }
        else
        {
            page++;
        }
        // set these true so it isn't called repetedly in onGUI
        // if they aren't needed they will be set false instantly
        minusB0.SetActive(true);
        minusB1.SetActive(true);
        minusB2.SetActive(true);
    }
    public void prevPage()
    {
        if (page == 1)
        {
            page = 4;
        }
        else
        {
            page--;
        }
        // set these true so it isn't called repetedly in onGUI
        // if they aren't needed they will be set false instantly
        minusB0.SetActive(true);
        minusB1.SetActive(true);
        minusB2.SetActive(true);
    }

    
}
