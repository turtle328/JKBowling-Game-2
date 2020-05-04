using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMannequin : MonoBehaviour
{
    public Inventory inventory;
    public GameObject mannequinOnStand;


    private void OnMouseEnter()
    {
        GameObject selectedItem = inventory.GetCurrentItem();
        if (selectedItem != null)
        {
            if (selectedItem.name.Equals("actionfigure"))
            {
                DisplayManager.Instance.SetHelpText("Press E to place model");
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
                if (selectedItem.name.Equals("actionfigure"))
                {
                    inventory.RemoveCurrentItem();
                    mannequinOnStand.SetActive(true);
                    this.enabled = false;
                }
            }
        }
    }
}
