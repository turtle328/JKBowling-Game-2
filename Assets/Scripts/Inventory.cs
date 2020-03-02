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
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
         KeyCode.Alpha0
     };

    public List<GameObject> inventory;
    public static float pickupCD = 0;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            inventory.Add(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
                        inventory[i] = null;
                        DisplayManager.Instance.SetImage(i, null);
                    }
                }
            }
        }
    }
}
