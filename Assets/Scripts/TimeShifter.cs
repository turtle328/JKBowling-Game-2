using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShifter : MonoBehaviour
{
    public int currentWorldState = 0;
    public int maxWorldState = 2;

    public List<GameObject> world0Objects;
    public List<GameObject> world1Objects;

    public Dictionary<int, List<GameObject>> worldStateObjects;

    void Start()
    {
        worldStateObjects = new Dictionary<int, List<GameObject>>();
        worldStateObjects.Add(0, world0Objects);
        worldStateObjects.Add(1, world1Objects);
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int newWorldState = (currentWorldState + 1) % maxWorldState;
            ToggleWorldState(newWorldState);
        }
    }

    private void ToggleWorldState(int newWorldState)
    {
        foreach ( GameObject obj in worldStateObjects[currentWorldState])
        {
            obj.SetActive(false);
        }
        foreach ( GameObject obj in worldStateObjects[newWorldState])
        {
            obj.SetActive(true);
        }

        currentWorldState = newWorldState;
    }
}
