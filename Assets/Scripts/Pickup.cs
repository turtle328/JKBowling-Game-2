﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player;
    private new Rigidbody rigidbody;

    private void Update()
    {
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
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<Invetory>().invetory.Add(gameObject);
            gameObject.SetActive(false);
        }
    }

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
}
