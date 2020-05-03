using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerWorld1 : MonoBehaviour
{
    // singleton implementation
    public static PuzzleManagerWorld1 Instance { get; private set; }

    // is puzzle complete?
    public bool puzzleComplete = false;

    // Reference to all key items needed for this world
    public Inventory inventory;
    public GameObject throwableRock;
    public GameObject tree;
    public GameObject key;
    public GameObject door;

    // timeshifter reference to shift world once puzzle is done
    public TimeShifter ts;

    // singleton implementation setup
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // drops key from tree, to be called when tree detections a collsion with the rock
    public void DropKey()
    {
        key.GetComponent<Rigidbody>().useGravity = true;
        Destroy(throwableRock.GetComponent<Pickup>());
    }
}
