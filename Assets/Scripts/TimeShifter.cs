﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TimeShifter : MonoBehaviour
{
    // ====================
    //   World State Data
    // ====================

    public List<WorldState> WorldStates = new List<WorldState>();
    public int currentWorldStateNum = 0;


    // ========================
    //   Time Management Data
    // ========================

    public Clock clock;         // The script associated with the clock on the wall
    

    void Start()
    {   
        WorldState ws00 = WorldState.GetWorldState(0);
        ws00.UpdateGameObjectList();

        WorldState ws01 = WorldState.GetWorldState(1);
        ws01.UpdateGameObjectList();

        WorldState ws02 = WorldState.GetWorldState(2);
        ws02.UpdateGameObjectList();

        WorldStates.Add(ws00);
        WorldStates.Add(ws01);
        WorldStates.Add(ws02);

        clock.hour = ws00.clock_hour;
        clock.minutes = ws00.clock_minute;

        ResetWorldStates();
        DisplayManager.Instance.SetHelpText("");
    }


    /// <summary>
    /// Updates the world to reflect the provided world state
    /// </summary>
    /// <param name="newWorldState"></param>
    private void ChangeWorldState(int newWorldState)
    {
        if ( newWorldState >= 0 && newWorldState < WorldState.MAX_WORLDNUM )
        {
            WorldState oldWS = WorldStates[currentWorldStateNum];
            WorldState newWS = WorldStates[newWorldState];
            int direction = newWorldState - currentWorldStateNum;

            foreach (GameObject obj in oldWS.keyItems)
            {
                if (obj != null)
                {
                    KeyItem k = obj.GetComponent<KeyItem>();
                    if (k.attachedToWorldState)
                    {
                        obj.SetActive(false);
                    }
                }
            }

            foreach (GameObject obj in newWS.keyItems)
            {
                if (obj != null)
                {
                    KeyItem k = obj.GetComponent<KeyItem>();
                    if (k.attachedToWorldState)
                    {
                        obj.SetActive(true);
                    }
                }
            }

            clock.UpdateTime(newWS.clock_hour, newWS.clock_minute);
            currentWorldStateNum = newWorldState;
            DisplayManager.Instance.SetHelpText(newWS.name);
        }
    }

    /// <summary>
    /// Set all objects to be hidden except for the objects in the first world.
    /// Lets all objects be enabled in editor without showing them in the game.
    /// </summary>
    private void ResetWorldStates()
    {
        for (int i = 1; i < WorldState.MAX_WORLDNUM; i++)
        {
            foreach (GameObject k in WorldStates[i].keyItems)
            {
                k.SetActive(false);
            }
        }
    }


    // =================
    //   INTERACTIVITY
    // =================

    private void OnMouseEnter()
    {
        DisplayManager.Instance.SetHelpText(WorldStates[currentWorldStateNum].name);
    }

    private void OnMouseExit()
    {
        DisplayManager.Instance.SetHelpText("");
    }

    private void OnMouseOver()
    {
        int newWorldStateInd = currentWorldStateNum;

        if (Input.GetKeyDown(KeyCode.E))
        {
            newWorldStateInd = Mathf.Min((currentWorldStateNum + 1), WorldState.MAX_WORLDNUM);
        }
        else if ( Input.GetKeyDown(KeyCode.Q))
        {
            newWorldStateInd = Mathf.Max((currentWorldStateNum - 1), 0);
        }

        // We only want to mess with the scene when we need to
        if ( newWorldStateInd != currentWorldStateNum )
        {
            ChangeWorldState(newWorldStateInd);
        }
    }
}
