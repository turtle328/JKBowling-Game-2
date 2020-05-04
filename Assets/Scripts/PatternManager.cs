using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public Puzzle02Manager _mngr;
    public Inventory inventory;
    public GameObject shirt;

    public Material mat01;
    public Material mat02;
    public Material mat03;
    public Material mat04;

    bool attachedCloth = false;


    // Start is called before the first frame update
    void Start()
    {
        _mngr = Puzzle02Manager.Instance;
    }


    private void OnMouseEnter()
    {
        GameObject selectedItem = inventory.GetCurrentItem();
        if (selectedItem != null)
        {
            if (selectedItem.name.Equals("cloth (clean)"))
            {
                DisplayManager.Instance.SetHelpText("Press E to attach cloth");
            }
            else if ( selectedItem.name.Contains("Pattern") && attachedCloth )
            {
                DisplayManager.Instance.SetHelpText("Press E to apply pattern");
            }
        }
    }

    private void OnMouseExit()
    {
        DisplayManager.Instance.SetHelpText("");
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject selectedItem = inventory.GetCurrentItem();
            if (selectedItem != null)
            {
                if (selectedItem.name.Equals("cloth (clean)"))
                {
                    inventory.RemoveCurrentItem();
                    shirt.SetActive(true);
                    attachedCloth = true;
                    DisplayManager.Instance.TriggerEventText("It's too plain... Is there a pattern I can use?");
                    
                    foreach ( GameObject pattern in _mngr.patterns )
                    {
                        pattern.GetComponent<Pickup>().enabled = true;
                    }

                }
                else if (selectedItem.name.Contains("Pattern") && attachedCloth )
                {
                    Material newMat = null;
                    int matNum = 0;
                    switch (selectedItem.name)
                    {
                        case "Pattern 01":
                            newMat = mat01;
                            matNum = 1;
                            break;
                        case "Pattern 02":
                            newMat = mat02;
                            matNum = 2;
                            break;
                        case "Pattern 03":
                            newMat = mat03;
                            matNum = 3;
                            break;
                        case "Pattern 04":
                        default:
                            newMat = mat04;
                            matNum = 4;
                            break;
                    }
                    shirt.GetComponent<Renderer>().material = newMat;
                    _mngr.OnChangedPatternPuzzle(matNum);
                }
            }
        }
    }

}
