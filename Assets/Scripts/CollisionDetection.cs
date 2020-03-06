using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    // public field
    public GameObject key;
    public GameObject open;

    public Inventory In;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.position == key.transform.position)
        {
            if (open.activeSelf == false)
            {
                open.SetActive(true);
            }
            else
            {
                open.SetActive(false);
            }
        }

    }

    void OnMouseDown()
    {
        for (int i = 0; i < In.inventory.Count; i++)
        {
            if (In.inventory[i] == key)
            {
                if (open.activeSelf == false)
                {
                    open.SetActive(true);
                }
                else
                {
                    open.SetActive(false);
                }
            }
        }
    }
}
