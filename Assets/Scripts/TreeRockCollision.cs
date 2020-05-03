using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRockCollision : MonoBehaviour
{
    // rock reference
    public GameObject rock;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == rock)
        {
            PuzzleManagerWorld1.Instance.DropKey();
        }
    }
}
