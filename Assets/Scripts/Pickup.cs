using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player;
    public bool throwable = false;

    private new Rigidbody rigidbody;
    GameObject[] inv;


    void Start()
    {
        inv = player.GetComponent<Inventory>().inventory;
    }

    private void Update()
    {

    }

    private void OnMouseEnter()
    {
        DisplayManager.Instance.SetHelpText(gameObject.GetComponent<KeyItem>().prettyName);
        GetComponent<Renderer>().material.SetFloat("_Outline", 0.2f);
    }

    private void OnMouseExit()
    {
        DisplayManager.Instance.SetHelpText("");
        GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int index = 0;
            while (inv[index] != null)
            {
                index++;
                if ( index >= Inventory.MAX_INVENTORY )
                {
                    break;
                }
            }

            if (index < Inventory.MAX_INVENTORY)
            {
                DisplayManager.Instance.SetHelpText("");
                inv[index] = gameObject;
                
                KeyItem k = gameObject.GetComponent<KeyItem>();
                k.attachedToWorldState = false;
                DisplayManager.Instance.SetImage(index, k.inventoryImage);
                
                gameObject.SetActive(false);
            }
        }
    }
}
