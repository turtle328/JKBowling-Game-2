using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanRag : MonoBehaviour
{
    Puzzle02Manager _mngr;
    public Inventory inventory = null;
    public GameObject cleanCloth;


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
            if ( selectedItem.name.Equals("cloth") )
            {
                DisplayManager.Instance.SetHelpText("Press E to wash the cloth");
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
            if ( selectedItem != null )
            {
                if ( selectedItem.name.Equals("cloth") )
                {
                    inventory.ReplaceCurrentItem(cleanCloth);
                    DisplayManager.Instance.TriggerEventText("You have cleaned the cloth...");
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
