using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle02Manager : MonoBehaviour
{
    public static Puzzle02Manager Instance { get; private set; }

    public DisplayManager _displayMngr;

    // BEAR SHIRT PUZZLE
    public int[] knownPatterns;
    public GameObject stuffedToy;
    public GameObject rag;

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


    public void OnChangedPatternPuzzle(int chosenPattern)
    {
        if ( chosenPattern == 0 )
        {
            OnSolvedPatternPuzzle();
        }
    }

    void OnSolvedPatternPuzzle()
    {
        // Disable the stuffed toy interaction
        // stuffedToy.GetComponent<PatternManager>().enabled = false;
        
        // Spawn a mannequin
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
    }

}
