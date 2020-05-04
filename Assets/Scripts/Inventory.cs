using System.Collections;
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
            curIndex = curIndex - 1;
            if (curIndex < 0)
            {
                curIndex = MAX_INVENTORY - 1;
            }
            
            DisplayManager.Instance.ToggleHighlight(prevIndex, false);
            DisplayManager.Instance.ToggleHighlight(curIndex, true);
            DisplayManager.Instance.SetHelpText("");
        }

        // mouse wheel down
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            prevIndex = curIndex;
            curIndex = (curIndex + 1) % MAX_INVENTORY;

            DisplayManager.Instance.ToggleHighlight(prevIndex, false);
            DisplayManager.Instance.ToggleHighlight(curIndex, true);
            DisplayManager.Instance.SetHelpText("");
        }

        // place/throw object
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (inventory[curIndex] != null)
            {
                // grab object to check if it's a throwable
                Pickup p = inventory[curIndex].GetComponent<Pickup>();

                if (p.throwable)
                // throw it
                {
                    p.transform.position = transform.position + transform.forward * 2;
                    // get rigidbody of object
                    Rigidbody rb = p.GetComponent<Rigidbody>();
                    RaycastHit hit;
                    Vector3 forward = transform.GetChild(0).forward;
                    Vector3 up = transform.GetChild(0).up;
                    Vector3 origin = transform.position + up;

                    if (Physics.Raycast(origin, forward, out hit))
                    {
                        p.transform.position = transform.position + transform.up * 0.8f;
                        Vector3 vel = (hit.point - transform.position) * 2;
                        rb.velocity = Vector3.ClampMagnitude(vel, 20);

                        // Debug code
                        //GameObject debugSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        //Destroy(debugSphere.GetComponent<SphereCollider>());
                        //debugSphere.transform.position = hit.point;

                        //GameObject originSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        //Destroy(originSphere.GetComponent<SphereCollider>());
                        //originSphere.transform.position = origin;
                        //originSphere.GetComponent<Renderer>().material.color = Color.red;
                    }

                    inventory[curIndex].SetActive(true);
                    inventory[curIndex] = null;
                    DisplayManager.Instance.SetImage(curIndex, null);
                }
            }
        }
    }

    public GameObject GetCurrentItem()
    {
        return inventory[curIndex];
    }

    public void RemoveCurrentItem()
    {
        inventory[curIndex] = null;
        DisplayManager.Instance.SetImage(curIndex, null);
        DisplayManager.Instance.SetHelpText("");
    }

    public void ReplaceCurrentItem(GameObject newItem)
    {
        KeyItem k = newItem.GetComponent<KeyItem>();
        inventory[curIndex] = newItem;
        DisplayManager.Instance.SetImage(curIndex, k.inventoryImage);
        DisplayManager.Instance.SetHelpText("");
    }

    public void RemoveItemAtIndex(int index)
    {
        inventory[index] = null;
        DisplayManager.Instance.SetImage(index, null);
        DisplayManager.Instance.SetHelpText("");
    }
}

