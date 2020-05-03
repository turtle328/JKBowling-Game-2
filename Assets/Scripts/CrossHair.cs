using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrossHair : MonoBehaviour
{
    public Texture2D crosshairImage;
    public TextMeshProUGUI text;
    private int crosshairSize = 25;

    void OnGUI()
    {
        if (text.alpha <= 0)
        {
            float xMin = (Screen.width / 2) - (crosshairSize / 2);
            float yMin = (Screen.height / 2) - (crosshairSize / 2);
            GUI.DrawTexture(new Rect(xMin, yMin, crosshairSize, crosshairSize), crosshairImage);
        }
    }
}
