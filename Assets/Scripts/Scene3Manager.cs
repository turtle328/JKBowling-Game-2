using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Manager : MonoBehaviour
{

    public Texture2D page1;
    private int page1Width = 675;
    private int page1Height = 900;
    public Texture2D page2;
    private int page2Width = 675;
    private int page2Height = 900;
    public Texture2D page3;
    private int page3Width = 675;
    private int page3Height = 900;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnGUI()
    {
        float xMin1 = (Screen.width / 2) - page1Width/2;
        float yMin1 = (Screen.height / 2) - page1Height/2;
        GUI.DrawTexture(new Rect(xMin1, yMin1, page1Width, page1Height), page1);
        float xMin2 = (Screen.width / 2) - page2Width / 2;
        float yMin2 = (Screen.height / 2) - page2Height / 2;
        GUI.DrawTexture(new Rect(xMin2, yMin2, page2Width, page2Height), page2);
        float xMin3 = (Screen.width / 2) - page3Width / 2;
        float yMin3 = (Screen.height / 2) - page3Height / 2;
        GUI.DrawTexture(new Rect(xMin3, yMin3, page3Width, page3Height), page3);
    }
}
