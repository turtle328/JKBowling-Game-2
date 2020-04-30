using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class IWorldState
{
    // TODO: update this as max world states increases
    public static readonly int MAX_WORLDNUM = 3;

    public static WorldState GetWorldState(int worldNum)
    {
        WorldState ws = null;

        if (worldNum > MAX_WORLDNUM)
        {
            // Could potentially throw an exception here as well, if
            // we wanted to go that route on this codebase
            Debug.LogError("Provided world number out of bounds.");
        }
        else
        {
            string path = "Assets/Data/" + worldNum + ".dat";
            if ( File.Exists(path) )
            {
                string jsonData = File.ReadAllText(path);
                ws = JsonUtility.FromJson<WorldState>(jsonData);
            }
        }

        return ws;
    }
}

[System.Serializable]
public class WorldState : IWorldState
{
    public List<string> unique_objects;
    public List<GameObject> keyItems;
    public int clock_hour;
    public int clock_minute;
    public string name;
    public string object_container_name;

    /// <summary>
    /// Iterates through the unique_objects list
    ///     (strings of object names)
    /// and retrieves the GameObjects with those names.
    /// 
    /// As this function iterates over the entire
    /// list of unique objects and clobbers the
    /// GameObject list on each call, it should
    /// really only be used once immediately after
    /// the WorldState object is loaded.
    /// </summary>
    public void UpdateGameObjectList()
    {
        keyItems.Clear();

        // this works for inactive items also
        Transform containers = GameObject.Find("WorldObjects").GetComponentInChildren<Transform>(true);

        foreach (Transform container in containers )
        {
            if ( container.name == object_container_name )
            {
                Transform items = container.GetComponentInChildren<Transform>(true);
                foreach (Transform item in items)
                {
                    if (unique_objects.Contains(item.name))
                    {
                        keyItems.Add(item.gameObject);
                    }
                }
                return;
            }
        }
    }

}
