﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player;
    public Texture2D tex;

    private new Rigidbody rigidbody;
    GameObject[] inv;

    void Start()
    {
        inv = player.GetComponent<Inventory>().inventory;
    }

    private void Update()
    {
        /*
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody.useGravity == false)
        {
            float rotation = -player.GetChild(0).localRotation.x;
            float yPos = 1.0f;
            if (rotation > 0)
            {
                yPos += Mathf.Sin(rotation) * 6;
            }
            else
            {
                yPos += Mathf.Sin(rotation) * 2;

                if (yPos < 0.5f)
                {
                    yPos = 0.5f;
                }
            }
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
        */
    }

    private void OnMouseEnter()
    {
        DisplayManager.Instance.SetHelpText(gameObject.GetComponent<KeyItem>().prettyName);
    }

    private void OnMouseExit()
    {
        DisplayManager.Instance.SetHelpText("");
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

        // We can bring this back if we really want it

        /*
        for (int i = 0; i < Inventory.keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(Inventory.keyCodes[i]))
            {
                if (inv[i] == null)
                {
                    DisplayManager.Instance.SetHelpText("");
                    Inventory.pickupCD = 0.1f;
                    inv[i] = gameObject;
                    gameObject.SetActive(false);
                    DisplayManager.Instance.SetImage(i, tex);
                }
            }
        }
        */
    }

    /*
    void OnMouseDown()
    {
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        transform.position = player.position + player.forward * 2;
        transform.parent = player.transform;
    }

    void OnMouseUp()
    {
        transform.parent = null;
        rigidbody.useGravity = true;
        rigidbody.constraints = RigidbodyConstraints.None;
    }
    */
}
