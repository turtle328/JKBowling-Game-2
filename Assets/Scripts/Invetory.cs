using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory : MonoBehaviour
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

    public GameObject[] invetory;
    public static float pickupCD = 0;

    // Start is called before the first frame update
    void Awake()
    {
        invetory = new GameObject[keyCodes.Length];
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
                    if (invetory[i] != null)
                    {
                        invetory[i].SetActive(true);
                        invetory[i].transform.position = transform.position + transform.forward * 2;
                        invetory[i] = null;
                        DisplayManager.Instance.SetImage(i, null);
                    }
                }
            }
        }
    }
}
