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
    public static float pickupCD = 0;

    // Start is called before the first frame update
    void Awake()
    {
        inventory = new GameObject[MAX_INVENTORY];
    }

    // Update is called once per frame
    void Update()
    {
        for ( int i = 0; i < keyCodes.Length; i++ )
        {
            if ( Input.GetKeyDown(keyCodes[i]) )
            {
                if (inventory[i] != null)
                {
                    inventory[i].SetActive(true);
                    inventory[i].transform.position = transform.position + transform.forward * 2;
                    inventory[i] = null;
                    DisplayManager.Instance.SetImage(i, null);
                }
            }
        }



        /*
        if (pickupCD > 0)
        {
            pickupCD -= Time.deltaTime;
        }

        else
        {
            
            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    // dropping the item as long there is one at the #'s position

                    if (inventory[i] != null)
                    {
                        inventory[i].SetActive(true);
                        inventory[i].transform.position = transform.position + transform.forward * 2;
                        if (timeShifter.currentWorldState == 0)
                        {
                            for (int y = 0; y < timeShifter.world1Objects.Count; y++)
                            {
                                if (timeShifter.world1Objects[y] == inventory[i])
                                {
                                    timeShifter.world1Objects.RemoveAt(y);
                                    timeShifter.world0Objects.Add(inventory[i]);
                                }
                            }
                        }
                        else if (timeShifter.currentWorldState == 1)
                        {
                            for (int y = 0; y < timeShifter.world0Objects.Count; y++)
                            {
                                if (timeShifter.world0Objects[y] == inventory[i])
                                {
                                    timeShifter.world0Objects.RemoveAt(y);
                                    timeShifter.world1Objects.Add(inventory[i]);
                                }
                            }
                        }
                    }
                    inventory[i] = null;
                    DisplayManager.Instance.SetImage(i, null);
                }
            }
        }*/
    }
}

