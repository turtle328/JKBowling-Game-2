using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory : MonoBehaviour
{
    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };

    public List<GameObject> invetory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < invetory.Count; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                invetory[i].SetActive(true);
                invetory[i].transform.position = transform.position + transform.forward * 2;
                invetory.RemoveAt(i);
            }
        }
    }
}
