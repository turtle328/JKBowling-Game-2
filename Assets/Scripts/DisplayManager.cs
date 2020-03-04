using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    private static DisplayManager instance;
    public static DisplayManager Instance { get { return instance; } }

    public Texture2D emptyTexture;
    public GameObject placeholder;
    public List<GameObject> images;
    TextMeshProUGUI helpText;
    float margins = 250;
    float spaceBetween = 1.1f;

    // Start is called before the first frame update
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
        helpText = GetComponentInChildren<TextMeshProUGUI>();
        helpText.text = "";
        RectTransform placeHolderRect = placeholder.GetComponent<RectTransform>();
        float width = GetComponent<RectTransform>().rect.width - margins * 2;
        float invWidth = width / (Inventory.keyCodes.Length - 1) * 1/spaceBetween;
        if (invWidth > 100)
        {
            invWidth = 100;
            spaceBetween = width / (invWidth * 9);
        }
        Vector2 rectSize = new Vector2(invWidth, invWidth);
        placeHolderRect.sizeDelta = rectSize;

        for (int i = 0; i < Inventory.keyCodes.Length; i++)
        {
            GameObject temp = Instantiate(placeholder);
            float placeHolderRectX = (invWidth * i) * spaceBetween + margins;
            Vector3 pos = new Vector3(placeHolderRectX, rectSize.y / 2 + 20);
            temp.GetComponent<RectTransform>().SetPositionAndRotation(pos, Quaternion.identity);
            temp.transform.SetParent(gameObject.transform);
            images.Add(temp);
        }
    }

    public void SetHelpText(string text)
    {
        helpText.text = text;
    }

    public void SetImage(int pos, Texture2D image)
    {
        if (image != null)
        {
            images[pos].GetComponent<RawImage>().texture = image;
        }
        else
        {
            images[pos].GetComponent<RawImage>().texture = emptyTexture;
        }
    }
}
