using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public Texture2D crosshairImage;
    private int crosshairSize = 25;

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairSize / 2);
        float yMin = (Screen.height / 2) - (crosshairSize / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairSize, crosshairSize), crosshairImage);
    }
}
