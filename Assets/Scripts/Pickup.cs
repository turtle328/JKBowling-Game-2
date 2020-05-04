using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player;
    public bool throwable = false;
    public float outlineWidth = 0.2f;

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
        if ( this.enabled )
        {
            DisplayManager.Instance.SetHelpText(gameObject.GetComponent<KeyItem>().prettyName);
            if (GetComponent<Renderer>() != null)
            {
                GetComponent<Renderer>().material.SetFloat("_Outline", outlineWidth);
            }
        }
    }

    private void OnMouseExit()
    {
        if ( this.enabled )
        {
            DisplayManager.Instance.SetHelpText("");
            if (GetComponent<Renderer>() != null)
            {
                GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);
            }
        }
    }

    private void OnMouseOver()
    {
        if (this.enabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DisplayManager.Instance.SetHelpText("");
                if (GetComponent<Renderer>() != null)
                {
                    GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);
                }

                // does it have key controller? then give key to player
                KeyController key = GetComponent<KeyController>();
                if (key != null)
                {
                    key.GiveKey();
                    return;
                }

                int index = 0;
                while (inv[index] != null)
                {
                    index++;
                    if (index >= Inventory.MAX_INVENTORY)
                    {
                        break;
                    }
                }

                if (index < Inventory.MAX_INVENTORY)
                {
                    inv[index] = gameObject;

                    KeyItem k = gameObject.GetComponent<KeyItem>();
                    k.attachedToWorldState = false;
                    DisplayManager.Instance.SetImage(index, k.inventoryImage);

                    gameObject.SetActive(false);
                }
            }
        }
    }
}
