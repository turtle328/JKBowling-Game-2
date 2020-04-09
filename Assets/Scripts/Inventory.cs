﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static public KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7

            // We can re-enable these if the inventory expands

         /*
         KeyCode.Alpha8,
         KeyCode.Alpha9,
         KeyCode.Alpha0
         */
     };

    public static readonly int MAX_INVENTORY = 7;

    public GameObject[] inventory;

    int curIndex = 0;
    int prevIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        inventory = new GameObject[MAX_INVENTORY];
    }

    // Update is called once per frame
    void Update()
    {
        // object select
        for ( int i = 0; i < keyCodes.Length; i++ )
        {
            if ( Input.GetKeyDown(keyCodes[i]) )
            {
                prevIndex = curIndex;
                curIndex = i;

                DisplayManager.Instance.ToggleHighlight(prevIndex, false);
                DisplayManager.Instance.ToggleHighlight(curIndex, true);
            }
        }

        // mouse wheel up
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            prevIndex = curIndex;
            curIndex = (curIndex + 1) % MAX_INVENTORY;

            DisplayManager.Instance.ToggleHighlight(prevIndex, false);
            DisplayManager.Instance.ToggleHighlight(curIndex, true);
        }

        // mouse wheel down
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            prevIndex = curIndex;
            curIndex = curIndex - 1;
            if (curIndex < 0)
            {
                curIndex = MAX_INVENTORY - 1;
            }

            DisplayManager.Instance.ToggleHighlight(prevIndex, false);
            DisplayManager.Instance.ToggleHighlight(curIndex, true);
        }

        // place/throw object
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (inventory[curIndex] != null)
            {
                inventory[curIndex].SetActive(true);
                inventory[curIndex].transform.position = transform.position + transform.forward * 2;
                inventory[curIndex] = null;
                DisplayManager.Instance.SetImage(curIndex, null);
            }
        }
    }
}

