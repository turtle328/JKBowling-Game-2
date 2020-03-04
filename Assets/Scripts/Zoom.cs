using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerCamera.fieldOfView = 15;
        }
        else
        {
            playerCamera.fieldOfView = 60;
        }
    }
}
