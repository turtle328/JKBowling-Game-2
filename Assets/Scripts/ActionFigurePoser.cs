using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFigurePoser : MonoBehaviour
{
    public Puzzle02Manager _mngr { get; set; }
    public bool isActive = true;

    Animator animator;
    public int standNum = 0;
    int selectedPose = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        _mngr = Puzzle02Manager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseEnter()
    {
        if (isActive)
        {
            DisplayManager.Instance.SetHelpText("Press E to change pose");
        }
    }

    private void OnMouseExit()
    {
        DisplayManager.Instance.SetHelpText("");
    }

    private void OnMouseOver()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                selectedPose++;
                selectedPose %= 3;

                animator.SetInteger("SelectedPose", selectedPose);

                if (_mngr.enabled)
                {
                    _mngr.OnChangedMannequinPuzzle(standNum, selectedPose);
                }
            }
        }
    }
}
