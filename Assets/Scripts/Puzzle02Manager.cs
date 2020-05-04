using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle02Manager : MonoBehaviour
{
    public static Puzzle02Manager Instance { get; private set; }

    public DisplayManager _displayMngr;
    public Inventory inventory;
    bool solvedFirstPart = false;

    // BEAR SHIRT PUZZLE
    public GameObject[] patterns;
    public GameObject cloth;
    public GameObject stuffedToy;
    public GameObject mannequin01;

    // MANNEQUIN POSE PUZZLE
    public GameObject figureStand01;
    public GameObject figureStand02;
    public GameObject figureStand03;
    public readonly int[] StandSolution = { 2, 1, 0 };
    public int[] currentStandPositions = {0, 0, 0 };

    // RACE PUZZLE
    public GameObject firstPlaceStand;
    public GameObject secondPlaceStand;
    public GameObject thirdPlaceStand;
    public GameObject[] RaceSolution;   // 0 is first, 1 is second, 2 is third
    public GameObject[] currentRacePositions;
    public GameObject mannequin02;

    // TRANSITION TO PUZZLE SET 03
    public GameObject bedroomKey;
    public GameObject door;
    DoorController dc;
    bool transitioned = false;
    public TimeShifter ts;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            firstPlaceStand.GetComponent<RacePlacement>().enabled = true;
            secondPlaceStand.GetComponent<RacePlacement>().enabled = true;
            thirdPlaceStand.GetComponent<RacePlacement>().enabled = true;

            cloth.GetComponentInChildren<Pickup>().enabled = true;
            stuffedToy.GetComponentInChildren<PatternManager>(true)._mngr = Instance;

            figureStand01.GetComponentInChildren<ActionFigurePoser>(true)._mngr = Instance;
            figureStand02.GetComponentInChildren<ActionFigurePoser>(true)._mngr = Instance;
            figureStand03.GetComponentInChildren<ActionFigurePoser>(true)._mngr = Instance;

            dc = door.GetComponent<DoorController>();
        }
    }

    void Update()
    {
        if ( !transitioned && dc.firstDoorOpened )
        {
            transitioned = true;
            DisplayManager.Instance.TriggerEventText("The world seems different...");
            ts.ChangeWorldState(2);
            this.enabled = false;
        }
    }


    public void OnChangedPatternPuzzle(int chosenPattern)
    {
        if ( chosenPattern == 1 )
        {
            OnSolvedPatternPuzzle();
        }
        else
        {
            _displayMngr.TriggerEventText("That doesn't look quite right...");
        }
    }

    void OnSolvedPatternPuzzle()
    {
        // Disable the stuffed toy interaction
        stuffedToy.GetComponent<PatternManager>().enabled = false;

        // Get rid of the patterns from the inventory
        for ( int i = 0; i < Inventory.MAX_INVENTORY; i++ )
        {
            if ( inventory.inventory[i] != null )
            {
                if ( inventory.inventory[i].name.Contains("Pattern") )
                {
                    inventory.RemoveItemAtIndex(i);
                }
            }
        }

        // Destroy any patterns the player didn't pick up
        foreach ( GameObject pattern in patterns )
        {
            if ( pattern != null )
            {
                Destroy(pattern);
            }
        }

        // Spawn a mannequin
        mannequin01.SetActive(true);
        ShowMannequinText();
    }


    public void OnChangedRacePuzzle(GameObject car, int place)
    {
        currentRacePositions[place] = car;
        bool solved = true;
        for ( int i = 0; i < 3; i++ )
        {
            if ( currentRacePositions[i] != RaceSolution[i] )
            {
                solved = false;
            }
        }

        if ( solved )
        {
            OnSolvedRacePuzzle();
        }
    }

    void OnSolvedRacePuzzle()
    {
        _displayMngr.SetHelpText("");

        firstPlaceStand.GetComponent<RacePlacement>().isActive = false;
        secondPlaceStand.GetComponent<RacePlacement>().isActive = false;
        thirdPlaceStand.GetComponent<RacePlacement>().isActive = false;

        // Spawn a mannequin
        firstPlaceStand.GetComponent<RacePlacement>().currentCar.SetActive(false);
        mannequin02.SetActive(true);
        ShowMannequinText();
    }


    public void OnChangedMannequinPuzzle(int standNum, int posNum)
    {
        currentStandPositions[standNum] = posNum;
        bool solved = true;
        for ( int i = 0; i < 3; i++ )
        {
            if ( currentStandPositions[i] != StandSolution[i] )
            {
                solved = false;
            }
        }

        if ( solved )
        {
            OnSolvedMannequinPuzzle();
        }
    }

    void OnSolvedMannequinPuzzle()
    {
        _displayMngr.SetHelpText("");

        figureStand01.GetComponentInChildren<ActionFigurePoser>().isActive = false;
        figureStand02.GetComponentInChildren<ActionFigurePoser>().isActive = false;
        figureStand03.GetComponentInChildren<ActionFigurePoser>().isActive = false;

        // Spawn the next bedroom key
        bedroomKey.SetActive(true);
    }


    void ShowMannequinText()
    {
        string msg = "";
        if ( solvedFirstPart )
        {
            msg = "Another model...?";
        }
        else
        {
            solvedFirstPart = true;
            msg = "Where did this model come from?";
        }

        _displayMngr.TriggerEventText(msg);
    }

}
