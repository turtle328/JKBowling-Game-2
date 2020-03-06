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
    public List<GameObject> inventory;
    public Clock clock;
    public GameObject sun;

    void Start()
    {
        inventory = GameObject.Find("FPSController").GetComponent<Inventory>().inventory;
        worldStateObjects = new Dictionary<int, List<GameObject>>();
        worldStateObjects.Add(0, world0Objects);
        worldStateObjects.Add(1, world1Objects);
    }

    private void OnMouseEnter()
    {
        DisplayManager.Instance.SetHelpText("Press 'e' to change time.");
    }

    private void OnMouseExit()
    {
        DisplayManager.Instance.SetHelpText("");
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int newWorldState = (currentWorldState + 1) % maxWorldState;
            ToggleWorldState(newWorldState);
        }
    }

    /*
    private void OnMouseDown()
    {
        int newWorldState = (currentWorldState + 1) % maxWorldState;
        ToggleWorldState(newWorldState);
    }*/

    private void ToggleWorldState(int newWorldState)
    {
        if (worldStateObjects[currentWorldState] != null)
        {
            foreach (GameObject obj in worldStateObjects[currentWorldState])
            {
                obj.SetActive(false);
            }
        }
        if (worldStateObjects[newWorldState] != null)
        {
            foreach (GameObject obj in worldStateObjects[newWorldState])
            {
                if (!inventory.Contains(obj))
                {
                    obj.SetActive(true);
                }
            }
        }

        // TODO: Update this to use a WorldState class rather than magic numbers
        if ( newWorldState == 0 )
        {
            // Clock display
            clock.hour = 11;
            clock.minutes = 20;

            // Sun is high
            sun.transform.eulerAngles = new Vector3(115, 0, 0);
        }
        else if ( newWorldState == 1 )
        {
            // Clock display
            clock.hour = 4;
            clock.minutes = 45;

            // Sun is setting
            sun.transform.eulerAngles = new Vector3(169, 0, 0);
        }


        currentWorldState = newWorldState;
    }
}
